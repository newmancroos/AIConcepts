import os
from azure.identity import DefaultAzureCredential
from azure.ai.projects import AIProjectClient

# =============================================================================
# CONFIGURATION & INITIALIZATION
# =============================================================================

endpoint = os.getenv("PROJECT_ENDPOINT")
workflow_name = os.getenv("WORKFLOW_NAME")
workflow_version = os.getenv("WORKFLOW_VERSION")

# Initialize Project Client
project_client = AIProjectClient(
    endpoint=endpoint,
    credential=DefaultAzureCredential(),
)

# =============================================================================
# MAIN INTERACTIVE LOOP
# =============================================================================


def interactive_loop():
    print("Interactive Workflow mode started. Type 'exit' or 'quit' to stop.")

    # Context manager ensures proper connection cleanup
    with project_client:
        openai_client = project_client.get_openai_client()

        # Create a single conversation to maintain state across turns
        try:
            conversation = openai_client.conversations.create()
            print(f"Started conversation session (ID: {conversation.id})")
        except Exception as e:
            print(f"Failed to create conversation session: {e}")
            return

        try:
            while True:
                try:
                    user_message_text = input("\nYou: ").strip()
                except (EOFError, KeyboardInterrupt):
                    print("\nExiting interactive mode...")
                    break

                if not user_message_text:
                    continue
                if user_message_text.lower() in ("exit", "quit"):
                    print("Exiting interactive mode...")
                    break

                print("\n[WORKFLOW] Executing...")
                print("=" * 50)

                # Prepare the agent reference payload targeting the workflow
                extra_body = {
                    "agent_reference": {
                        "name": workflow_name,
                        "version": workflow_version,
                        "type": "agent_reference",
                    }
                }

                try:
                    stream = openai_client.responses.create(
                        conversation=conversation.id,
                        input=user_message_text,
                        extra_body=extra_body,
                        stream=True,
                        metadata={"x-ms-debug-mode-enabled": "1"},
                    )

                    # Stream text output and workflow state changes dynamically
                    for event in stream:
                        event_type = getattr(event, "type", None)

                        # 1. Stream real-time text tokens
                        if event_type == "response.output_text.delta":
                            # Extract streaming delta text
                            text_chunk = (
                                getattr(event, "delta", None)
                                or getattr(event, "text", None)
                                or ""
                            )
                            if text_chunk:
                                print(text_chunk, end="", flush=True)

                        # 2. Add a new line when a text response section finishes
                        elif event_type in (
                            "response.output_text.done",
                            "response.text.done",
                        ):
                            print()

                        # 3. Handle Workflow Node / Actor Start
                        elif event_type == "response.output_item.added":
                            item = getattr(event, "item", None)
                            if (
                                item
                                and getattr(item, "type", None) == "workflow_action"
                            ):
                                action_id = getattr(item, "action_id", "unknown")
                                print(f"\n\n[Actor: '{action_id}']")

                        # 4. Handle Workflow Node Finished
                        elif event_type == "response.output_item.done":
                            item = getattr(event, "item", None)
                            if (
                                item
                                and getattr(item, "type", None) == "workflow_action"
                            ):
                                action_id = getattr(item, "action_id", "unknown")
                                status = getattr(item, "status", "unknown")
                                print(f" -> Finished '{action_id}' (Status: {status})")

                except Exception as e:
                    print(f"\nERROR during workflow execution: {e}")

                print("\n" + "=" * 50)

        finally:
            # Clean up the conversation container on exit
            print(f"Cleaning up conversation (ID: {conversation.id})...")
            try:
                openai_client.conversations.delete(conversation_id=conversation.id)
                print("Conversation deleted successfully.")
            except Exception as e:
                print(f"Failed to delete conversation: {e}")


if __name__ == "__main__":
    interactive_loop()
