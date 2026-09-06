# AI-103


- What Is AI Agent?
    * It is an autonomous software system that uses **Reasoning, Memory and External tools** to perceive its environment, make decisions and multi-step  actions to achieve the  goal.
    * AI Agent is not like a request to an LLM like ChatGPT-5 and get the response but it can perform muti-step tasks without human guidance for each step.
 
  
- Tokens
     * When we send text to an LLM, the model breaks the text into Tokens. It may be a word, part of word or punctuation marks
     * LLMs charge by tokens. They have also have token limits
     * As an Agent, it track token usage across multi-step conversation. Long histories cost more tokens and may exceed model limits.

- Messages
     * System Message  - It is hidden from the user and tells the agent how to behave, what are the boundaries. Persistent, Include with all the request. 
                         ex. You are a customer support agent for Contoso.
     * User Message    - It is what the user askes. ex. Give me the approximate price for a item

- Tool Calling
     * Ability of an agent to request and execute external functions like Search Database or Sending an Email
     * Tool Definition : A tool is any external capability that agent can use - Search API, Database queries, Email Sender.
     * How Tool calling works : The LLM output a special JSON structure saying "I need to call tool X with param Y. Agent code then execute the call.
     * Tool calling advantages : Real, and Live data not trained data.

- Memory
     * Storing information from past interactions to use future decisions.
     * Short-Term Memory (Session Context) - It is for on conversation session.
     * Long-Term Memory (User History) - Persists across sessions. Remember User preference like Shipping address

### Microsoft Foundry

- It is a cloud platform where we **build, deploy and manage** AI agents
- About
     * Foundry as One Stop shop : Foundry provides everything you nee; **model deployment, Identity management, tracing and safety tools**
     * Foundry VS Azure AI Studio : Foundry is a successor to Azure AI Studio with added facilities like** Entra Agent ID and Agent Service**
     * Three core Foundry components: ** Hub (Resource container), Projects (agent workspaces),  Agent Service (Running environment for deployed agents)**
