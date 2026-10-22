import os
import sys
from pathlib import Path
import yaml

from azure.ai.projects import AIProjectClient
from azure.ai.projects.models import WorkflowAgentDefinition
from azure.core.exceptions import HttpResponseError
from azure.identity import DefaultAzureCredential

# =============================================================================
# CONFIGURATION
# =============================================================================

project_endpoint = os.getenv("PROJECT_ENDPOINT")
yaml_file_path = Path("workflow.yaml")

# =============================================================================
# DEPLOYMENT FUNCTION
# =============================================================================


def deploy_workflow_from_file(
    project_client: AIProjectClient, file_path: Path
) -> object:
    """Reads a local workflow YAML file as-is and deploys it to Azure AI Foundry."""
    if not file_path.exists():
        raise FileNotFoundError(f"YAML file not found at: {file_path.resolve()}")

    # 1. Read raw YAML text directly from disk
    raw_yaml = file_path.read_text(encoding="utf-8")

    # 2. Extract agent name for SDK registration without altering raw_yaml
    parsed_meta = yaml.safe_load(raw_yaml) or {}
    workflow_name = parsed_meta.get("name")

    print(f"🔄 Deploying Workflow: {workflow_name}")
    print(f"📄 Source File: {file_path}")

    try:
        # 3. Deploy raw YAML content directly using WorkflowAgentDefinition
        workflow_agent = project_client.agents.create_version(
            agent_name=workflow_name,
            definition=WorkflowAgentDefinition(workflow=raw_yaml),
            headers={"Foundry-Features": "WorkflowAgents=V1Preview"},
        )
        print(f"   ✅ Workflow deployed successfully! (ID: {workflow_agent.id})")
        return workflow_agent

    except HttpResponseError as e:
        print(f"   ❌ Azure REST API Error during workflow upload:\n{e.message}")
        raise
    except Exception as e:
        print(f"   ❌ Unexpected deployment error: {str(e)}")
        raise


# =============================================================================
# MAIN SCRIPT
# =============================================================================


def main() -> int:
    print("🚀 Starting Declarative Workflow Deployment from File")
    print("=" * 60)

    try:
        credential = DefaultAzureCredential()
        with AIProjectClient(
            endpoint=project_endpoint,
            credential=credential,
            allow_preview=True,
        ) as project_client:

            # Deploy raw workflow.yaml
            deployed_workflow = deploy_workflow_from_file(
                project_client=project_client,
                file_path=yaml_file_path,
            )

            print(f"\nWorkflow Agent ID: {deployed_workflow.id}")

        return 0

    except Exception as e:
        print(f"\n❌ Script failed: {str(e)}")
        return 1


if __name__ == "__main__":
    sys.exit(main())
