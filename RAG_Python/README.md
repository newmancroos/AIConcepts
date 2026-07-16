# RAG using Python

Link : https://www.youtube.com/watch?v=HHSjuhVuQEk&list=PLhhO7g8ucBH7MzCKGDp8fLOuFgdpW4l5Z

Packages : 	LangChain
					Llmaindex



LangChain

<p>LangChain is an open-source framework used to build applications powered by large language models (LLMs). It acts as a bridge between an AI model (like GPT, Claude, or Gemini) and a developer's external data and tools, allowing the creation of complex workflows like chatbots, AI agents, and document search systems.</p>
<p>
Because large language models on their own are essentially standalone "brains" without access to the outside world, LangChain provides the "nervous system" to connect them to real-world resources.
</p>
<p>

## Why is it useful?

Instead of writing extensive, manual code for your application, LangChain provides pre-built modules to help with the following tasks: 

-   **Connecting to Data (RAG):** It helps split up local documents (such as PDFs, databases, or websites), convert them into a readable format, and pass the relevant parts to the LLM so it can answer questions based on your specific information. 

-   **Building AI Agents:** It gives language models "tools" like web search APIs, calculators, or custom software, allowing the AI to reason and take actions based on what the user asks.

-   **Memory:** It gives the AI a way to remember past conversations and context, creating a much more personalized and fluid experience.

-   **Model Agnosticism:** LangChain standardizes how developers interact with models. This makes it easy to switch from one AI provider to another without having to rewrite the entire application. 
</p>

<p>
<b>Context Size :</b>  Each model has its own context size, it is nothing but max token size. <br/>
For Example, gpt 4o mini;s context size is 126,000.

If you have a document that has more than 126000 token, you cannot upload it to gtp mini 4o, So we need to go for <br/>
	- Big LLM
	-  Using RAG
</p>
<p>
<b>Knowledge Cuttoff</b>
	Each LLM has it own training cutoff date so details after that date is not available in the model.<br/>
	For example gpt mini 4o's cutoff date is October 2023.	
</p>

