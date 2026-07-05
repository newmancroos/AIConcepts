# AIConcepts

# What is AI?

Ai is a branch of computer science that develops systems capable of performing tasks typically requiring human intelligence, such as reasoning, learning, problem-solving, and perception. It utilizes algorithms and massive datasets to identify patterns, make predictions, and generate content, aiming to improve efficiency and simulate human-like cognitive functions

It includes various sub fields such as
- Machine Learning
- Natural Language Processing
- Computer vision


* **Machine learning** is a subset of AI  that enables computers to learn from data and making prediction or decisions without being explicitly programmed for every specific task. Instead of hard-coded instructions, ML systems use statistical algorithms to detect patterns in vast datasets, improving their performance through experience.

**Natural Language Processing** is subset of AI that enables computers to understand, interpret and generate human language both written and spoken. NLP uses machine learning models, often based on deep learning, trained on large datasets to identify patterns. It is highly useful for managing the vast amount of textual data produced daily, such as social media posts, emails, and reports, in a consistent and efficient way
It involves 
		- Language Generation
		- Answering Questions
		- Text Classification
		- Sentiment Analysis
		- Machine Translation


**Generative AI**
It is abranch of AI that creates new content including text, image, music and code by learning from massive dataset. Unlike traditional AI that analyzes existing data, GenAI produces novel output that mimic human creativeity. ex, ChatGpt, DALL-E. Its uses model like Large Language Model (LLM) to understand and generate human like text and voice.
	**Prompt Engineering:**  the art and science of crafting, refining, and optimizing inputs (prompts) to guide large language models (LLMs) and generative AI toward producing accurate, relevant, and high-quality outputs. It involves designing specific instructions, providing context, and iterating on wording to maximize model performance.

Most Generative models can be accessible using Rest Api 


<img width="1119" height="724" alt="image" src="https://github.com/user-attachments/assets/8b51b43e-bc7b-43a0-ac33-55dbea5ffc9c" />



## Gen AI for .Net: Build LLM Apps with OpenAI and Ollama (Udumy) :

Github Link : https://github.com/mehmetozkaya/genai-for-dotnet/tree/main


## What are Large Language Model (LLM)?
* LLMs are advanced AI models trained on large datasets - massive amounts of text data from books, websites, research papers
* They can understand, generate and process natural language that mimics natural human communication.
* These models are heart of AI chatbots,  content creation tools, translation services
* Basically LLMs are AI specialized natural language.

- LLM first tokenize the sentance into small tokens


**- What is Token?**
     * A token is a small unit of text that the model can understand
     * Toekn can be a entire word, a punctuation or a piece of a word
	 * Ex.
    		"Hello, how are you?"  -> "Hello", "How", "Are" and "you"
     * LLM don't read sentances the way humans do;, instead, they rely on tokens to process the information
     
  **- What is Tokenization?**
    	- Process of splitting text into tokens
    	- LLMs use tokens to process and generate response
    
URL : https://platform.openai.com/tokenizer
<img width="1615" height="998" alt="image" src="https://github.com/user-attachments/assets/2865a7db-4e98-4f32-92fc-4592cd3afa5b" />

**- What is Small Language Models (SLM)?**
- Smaller, more efficient and scaled-down version of LLMs
- Retain key functionalities like text generation, classification, language understanding but with significantly fewer parameters (Millions of parameters but LLM trillions)
- This makes them faster, cheaper and more efficient to run.
- LLMS are powerful but it needs lot of computational power, Memory and storage but SLM are tuned for lower computational requirement, lower resource consumption
- Suitable for real-time apps, mobile, edge devices and specific tasks.
- 
    LLM Examples:
	    - ChatGpt 4O  (170 trillion params)
	    - Gemini (540 billions params)
	    - Llama (70 billions params)
	SLM Examples:
		- Llama3 (8 billions)
		- Phi-3 ( 3.8 - 7 billions) (Microsoft)
		- Gemma ( 2 - billions)  (Google)
		- Mixtral 8x7B ( 7 billions)
		- OpenELM ( .27 - 3 billions) Apple

- **Prompt Engineering**
	<b>What is Prompt?</b>
- Input or instruction you give to an LLM to guide its response
- It could be a question, a command or even just a phrase
- Prompt is a huge role in how the model responds

<b>What is Prompt Engineering?</b>
- Crafting and refining prompts to improve model responses

* When we create prompt, along with the subject, context is more important.
       
## RAG

Retrieval-Augmented Generation (RAG) is an AI framework that improves Large Language Model (LLM) accuracy by retrieving data from external, trusted knowledge sources before generating a response. It acts like an "open-book exam" for AI, reducing hallucinations and allowing for up-to-date, specialized answers without retraining the model.

**Key Components and Benefits:**

-   **How it Works:** When a user asks a question, the system searches (retrieves) relevant documents or data, appends them to the prompt, and asks the LLM to generate an answer based on this new information.
-   **External Knowledge:** RAG can access internal company databases, PDFs, or live web data, which are not included in the LLM's static training data.
-   **Key Benefits:**
    -   **Accuracy:** Reduces hallucinations by grounding answers in retrieved facts.
    -   **Up-to-date Information:** Accesses the latest data without needing to retrain the model.


**What Can I build with AI and .NET?**
- Language Processing
	 Build <b>chatbot</b> that can understand and response to user queries or create <b>assistants</b> that generate new content. 
- Computer Vision
	Integrate models to identify object in images or videos -  useful for sueveillance, Inverntory management
- Audio Generation
	 Synthesized voices to intract with customers in a more natural way, creating voice-based assistants or audio notifications
- Classification and Prediction
	Predict the severity of the customer-reported issue or categorize product information

**AI frameworks and SDKs for .NET**

- net offers rich set of libraries and SDKs for integrating AI into apps


  <img width="1490" height="393" alt="image" src="https://github.com/user-attachments/assets/f2da2cbc-1a7a-4701-a00d-76482c4e3965" />


- Microsoft.Extensions.Ai Library
	Collection of libraries is designed to simplify AI integrations, consistent way to interact with different AI services.
- Sematic Kernel for .NET
	Structure complex AI workflow, combine multiple AI services and data sources w/ Plugins and Extensions.
- .NET SDKs for OpenAI Models
	Official packages that make request to OpenAI's GPT and embedding endpoints
- .NET SDKs for Azure AI Services
	Including vision, speech, language understanding  , leverage pre-trained models.


 **Microsoft.Extensions.Ai Library**
- Using Microsoft.Extensions.Ai library reference we can use the functionalities within Microsoft.Extensions.Ai.Abstractions provide connection between our application and LLM clients and AI services  like
					- Semantic Kernet
					- OpenAI
					- LLM Communitity pacjages
					- Azure AI Inference 
					- Ollama
					- Github Models

  <img width="1558" height="766" alt="image" src="https://github.com/user-attachments/assets/376029f9-8117-444b-a281-40f4c5ba2160" />

  
**Semantic Kernel (AI Orchestration Framework)**

- Open source SDK designed to streamline the integration of AI capabilities into existing apps.
- Building blocks
	- <b>Connections</b> - Bridge between your application code and external A services
	- <b>Plugins</b> - Encapsulate functionalities that your AI application might need. We may call Sematic function that is  AI functions and Native functions that is our code base like API
	- <b>Planner</b> - Orchestrates user requests by dynamically calling the right plugins and AI models
	- <b>Memory</b> Manage context and stored data for AI apps, leverage vector databases or cache (Use for history in the Chatbot application)
   


**Setup LLM Provider:** <br/>
	- Github Models (Free Service)    - https://github.com/marketplace/models <br/> 
	- Ollama (Local AI Model)  (Free Service)<br/>
	- Azure AI Foundry (Paid Service)   - https://ai.azure.com<br/>
	- OpenAI (ChatGpt)  (Paid Service) - https://platform.openai.com (https://developers.openai.com/api/docs/models)<br/>
	

**How to choose AI Model:** <br/>
	- <u><b>Cost and Subscription</b></u> <br/>
			If budget aren't an issue choose Azure AI services or start with Github models and easily shift to Azure AI services for production with changing API keys only.<br/>
	- <u><b>Performance ans Scalability</b></u> <br/>
		   Azure Open AI typically provides high availbility and can scale easily. Ollama relies on your local hardware <br/>
	- <u><b>Ease of Setup</b></u> <br/>
		  Github models can be integrated quickly. Ollama setup might be more involved initially. <br/>


**Note:** 
Even though we need to pay for Azure Ai models, using Github models and then using Azure Ai models is free with some Token limit. <br/>
					- Go to [https://github.com/marketplace/models](https://github.com/marketplace/models) <br/>
					- Select Models -> Catalog <br/>
					- In the Publisher dropdown select Azure OpenAI Service <br/>
					- Select any model <br/>
					- Select any message in the header - This will give response  <br/>
					- You can select Code tab to see code for accessing that model <br/>

					
**Create Access token in GitHub for a model:**

1. Select the model using this url https://github.com/marketplace/models
		ex. : OpenAI -GPT-4o mini
2.  Click Use this model


<img width="973" height="648" alt="image" src="https://github.com/user-attachments/assets/2905c22f-ab68-40e2-8fd6-3a4ebe017752" />

This dialog explain how to create Access token and enitre sample code is avaolable in gthis dialog

3.  Add Permission and select Model

   <img width="1394" height="787" alt="image" src="https://github.com/user-attachments/assets/6cb7c536-ad6a-4246-8c38-ee57ac675d53" />

   
   <img width="964" height="533" alt="image" src="https://github.com/user-attachments/assets/7efab2c8-4446-422d-906e-2b0db9b8fd21" />

   and Click Generate Token and copy the token becuase we cannot see gthe token again.

   

**What is Ollama  (Run LLMs locally)**
- Ollama is a platform to run LLM or SLM locally
- Offers private, secure AI solutions without requireing the cloud.
- Ideal of developers and businesses seeking offline AI capabilities w/ privacy, low latency and comntrol over AI model
- Excellent choice for those looking to integrate AI without depending on constant internet access.
- **Key  Feature of Ollama:** 

	-  Local Execution : Run LLMs and SMLs directly on your device
	-  Pre-built Models : Included optimize models for coding, chat, creative tasks and more
	- Privacy-First : All data remain on your machine, protecting sensitive info.
	-  Customization : Allow model fine-tuning and adaptation for a specific needs
	- Low latency : Fast response without network dependency.
- **Available Model in Ollama:**

	- Models : Llama, Gemma, qwen, phi, mistral
	- Code generation Models : codegemma, codellama  - AI assistants specialized in code generation
	- Creative Model : llva  - Text-to-image, story generation and poetry models
	- Domain-Specific Models : medllama  - Finance, healthcare and other inductry-specific LLMs


**Download Ollama and Llams 3.2  with Docker**

* https://ollama.com     - This step is need when we install Ollama locally
* Download Ollama      - This step is need when we install Ollama locally
* Download and Install Docker desktop
* We are going to run Ollama in docker
	* Goto dockerhub and  adn search for Ollama container image (https://hub.docker.com/)
		* https://hub.docker.com/r/ollama/ollama
		* docker run -d -v ollama:/root/.ollama -p 11434:11434 --name ollama ollama/ollama
			* Run above command in powershell as administrator 
			* docker ps will list down all running containers, so ollama is one of them
* Download Ollama model
	* Gt https://ollama.com
	* Click on Models
	* Search for llama and select/click on llama 3.2   (llama 3.3 is big so selected 3.2)
	* Select ollama:latest and copy the command to pull ollama to the docker
		* start interactive terminal in docker using following powershell command
			* docker exec -it ollama bash          --- Here ollama is container name
			* Run <b>ollama list </b> in the interactive terminal that listdown if any ollama model
     		* Run <b>ollama pull  llama3.2</b> in the interactive terminal that pull lamma3.2 model 
			* Run <b>ollama run llama3.2 </b>   --- This will pull ollama 3.2 model locally
			* Once it is available, we can even interact with ollama model in the interactive terminal itself
				* Ex. explain microservices in 20 words   -> ollama will respond to this prompt
 

**Text Completion using Github gpt-5-mini**

1. Using Guthub models with OpenAi gpt-5-mini (Minimal overhead to authenticating and sending the promqpt)
2. Switching OpenAi gpt-5-mini to to Ollama's Local Llama3.2 (It is online premises support without internet)



<img width="1212" height="770" alt="image" src="https://github.com/user-attachments/assets/6ce69a22-1993-4487-af7d-af34749dfd4a" />
<br/>

<img width="1503" height="781" alt="image" src="https://github.com/user-attachments/assets/b429ad9f-271f-412a-8dca-3a71bb87dbaa" />



<p>
 <b>Core Packages  :</b> <br/>
		- Microsoft.Extensions.AI <br/>
		-  Microsoft.Extension.AI.OpenAI <br/>
		- Microsoft.Extensions.Configuration <br/>
		- Microsoft.Extensions.Configurations.UserSecret
	</p>
 
 <p>
	 We are going to develop .Net solution for
	 - Text Completion
	 - Summarization
	 - Classification
	 - Sentiment Analysis
 </p>

Setps:
1. Open https://github.com/marketplace/models/azure-openai/gpt-5-mini
2. Click on Use this model, that open another page for that model
3. Select C# as Language and Azure Foundry Interface SDk as SDK
4. Follow the steps on the Model page



Note:
IChatClient is not only for request-response, chat like purpose it is also helps in Classification, Data Extraction, Translation etc. It is a universal task engine.

## Using Ollama Local LLM Vs Cloud Trad-off :

- **Ollama :** Total data privacy and offline capabilities. Zero API costs but, it uses your own computer resources
- **GitHub Model :** Incredible speed and access to the most powerful hardware. Zero local resource usage. But it required an internet connection, has potential cost

## Function Calling in LLM

LLMs can trigger external functions or APIs goes beyond text generation to perform actoions, Execute tasks like retriving data or booking appointments.

**What is Function for LLMs?**
Tool or API that can be invoked by the LLM, has spectifc name and set of parameters that passed to execute the function.
A function that retrive the current weather in a given location might need parameters like City and unit of measurement.



## .Net AI Vector searching using Vector embeddings and Vector

<br/>
<b>What is Vector?</b> <br/>
A Vector is a mathematical object that has both **magnitude and direction**, represented as a list of numbers : [1.2,3.4,-0.8]
Vectors are used to represent complex data in a way that AI models can process, numberical summaries of information.

<br/><br/>
<img width="989" height="710" alt="image" src="https://github.com/user-attachments/assets/4276700c-f3ed-4e41-bfc5-9d5b829cd54f" />
<br/><br/>

<b>What is Vector Embeddings?</b> <br/>
Dense numerical representation of data, capture the semantic meaning of text, image, audio or other data types.
<br/>
**Step1 : Input Data**
Start with raw data like a sentence, an image or a sound file
<br/>
**Step2 : Use an AI Embedding Model**
Pass the data through an AI model, like a Transformer model
<br/>
**Step 3 : Output Embedding**
Transforms the input into a vector embedding, list of numbers

<br/>
https://platform.openai.com/tokenizer

<br/>
<img width="1415" height="872" alt="image" src="https://github.com/user-attachments/assets/764990a1-007d-4188-a990-8089f66a4b0f" />

<br/>

<b>Why are Embedding important</b> <br/>
Compare and analyze data based on sematic meaning rather than surface-level features. If two sentances have similar meaning, their embedding will be close in high-dimensional space 
<br/>
<img width="892" height="673" alt="image" src="https://github.com/user-attachments/assets/148fe06b-674f-42cb-a4ad-b1a060798fa5" />

<br/>


## What is Vector Database?
Vector database is a specialized database to designed to store, manage and query high-dimensional vectors. Vectors are numerical representations that capture the semantic meaning of data. It can be Text, Image, Audio, Video or other kind of information. 
<br/>
Vector database Indexes and stores vector embedding for fast retrieval and similarity search.
<br/>
In vector database we can search information not only using exact key words also by context/meaning and concepts
<br/>
<img width="1394" height="490" alt="image" src="https://github.com/user-attachments/assets/2173858c-7c75-4373-b308-221d61a6c16a" />


In traditional databases retrieve exact word but Vector database is using context and concept, that means, Traditional database fetch exact data that matches "Laptop" but vector database will bring "Laptop", and "note book computer" etc.. 
<br/>
Vector database stores unstructured   document, images, audio, video, social media post...

<img width="1369" height="442" alt="image" src="https://github.com/user-attachments/assets/20275b39-2edf-4815-9a1f-c59638ec5dfc" />

<br/>
Vectors understand synonyms, paraphrases and even nuanced relationship between data points.

<br />

Sample Vector databases: <br />

- Chroma
- Qdrant
- Pinecone
- Weaviate

<br />
Only problem using these database is it has its own sdks, so if you use one database and in future is you want to change to another we need to rewrite our data access layer. For this the reason Microsoft.Extensions.VectorData.Abstractions  is designed to solve. It is a kind of adapter for vector databases. This sits between your application and vector database.

- Provides Common Interfaces
		- Abstract CRUD on vector data, standardized to connect vector Dbs  (Chroma, Qdrant, Pinecone, Weaviate) <br />
- Supports Vector and Text Search
		-  Unified methods for unserting embeddings, high-level search functions <br />
-  Decouples your app from Vendor SDKs
		- App code remains flexible, swap underlying vector store implementation with minimal changes <br />

* To use it in ASP.NET CORE/C#
	*	Nuget Packages  : Microsoft.Extensions.VectorData.Abstractions, Microsoft.Extensions.AI<br />
	*	VectorData Stores : Configure VectorData store in your app, Vectordata.Abstractions provides interfaces to Add, Update, Delete and search vector records<br />
	*	Vector and Text Search :  <br />
			*	Vector Search : Query a vector store by specifying an embedding vector and similarity metric, <br />
			*	Text Search : Convert text into embedding, then query the store using the same semantic approaches.<br />



<p>
	//Goto Ollama.com/library/all-minilm and download it
// OR in the interactive terminal write "ollama pull all-minilm" to download the model

// We suppose to iuse Microsoft.Extensions.AI.Ollama for embedding when we use Ollama models, but it is deprecated and not working.
//Embedding generator is the different from Open Ai and Ollama
//Odrant or Chroma are Vector databases


// Microsoft.Extensions.VectorData.Abstractions - Allows you to write your search and data storage logic
// against a standard interface, making it easy to sweap the underlying vector database later.
</p>

* Why Microsoft.Extension.VectorData.Abstraction?
  <p>
	  Microsoft.Extensions.VectorData.Abstractions
This is a .NET library that provides a standardized interface layer for working with vector databases, similar to how DbContext in Entity Framework abstracts over different SQL databases.
The Core Problem It Solves
Vector databases (Pinecone, Qdrant, Weaviate, Azure AI Search, etc.) all have different APIs. Without an abstraction, your code is tightly coupled to a specific vendor:
<pre>
// ❌ Tightly coupled to Qdrant — hard to swap later
var qdrantClient = new QdrantClient("localhost");
await qdrantClient.UpsertAsync("my-collection", new[] { new PointStruct { ... } });
</pre>

What the Abstraction Gives You
The library defines common interfaces your application code depends on:

<img width="732" height="568" alt="image" src="https://github.com/user-attachments/assets/463a56dc-cd20-4da7-b155-81c221d887de" />

<br/>
* <b>Swapping Backends via DI</b>
<pre>
	// Development — use in-memory store
builder.Services.AddInMemoryVectorStore();

// Production — swap to Azure AI Search, zero app code changes
builder.Services.AddAzureAISearchVectorStore(new Uri(endpoint), new AzureKeyCredential(key));

// Or Qdrant, Postgres (pgvector), Redis, etc.
builder.Services.AddQdrantVectorStore("localhost");
</pre>
  </p>


## RAG
- Retrival-Agumented-Generation enhances the model's ability to generate more accurate and relevant information by integrating external knowledge into the response.
- Bridge the gap with pre-trained knowledge and the real-time information that is not part of its training data.
- It pulls information from real-time or external knowledge sources, make responses more accurate and relevant to specific queries.


  <img width="2048" height="1365" alt="image" src="https://github.com/user-attachments/assets/2068aaff-4b12-4866-a3db-3cfe7a348709" />
  

Why RAG?
	* Pre-trained models are outdated and gives us inaccurate result. LLMs are only as current as their training data. GPT was trained on 2021, won't give any information from 2022 or beyond.
	* LLMs cannot access specific or proprietary data. Can't provide information from specific manuals or private database.


<img width="1595" height="604" alt="image" src="https://github.com/user-attachments/assets/04fc016c-cd99-4b0d-a573-a88210786f05" />




<b>Steps in RAG :</b>
1. Ingestion / Indexing   : 
	 - Collect information :  into to the knowledgebase (database, documents, real-time from Api)
	 - Organizing Information : Organize data for easily accessible in the retrieval step. Separate chunks, insert embedding and create indexes.
2. Retrieval :  Pulling information from external sources (knowledgebase) and creating the prompt. (Knowledgebase + query)
3. Generation : Go to the generation by sending query and knowledgebase to the LLM and get the final response



## Installing .Net AI Template

<p>
The purpose of installing the .NET AI templates in Visual Studio is to **instantly scaffold production-ready AI applications** without writing boilerplate setup code from scratch
</p>
<p>
These templates streamline the entire development process by offering the following core benefits and capabilities:
</p>
<p>
-   **Retrieval Augmented Generation (RAG):** Quickly build Blazor-based chat web apps that can ingest, search, and chat with your own custom documents (like PDFs and custom datasets)
</p>
<p>
- **Seamless Service Integrations:** Pre-configured scaffolding to connect with **GitHub Models**, **OpenAI**, **Azure OpenAI**, and local AI hosting environments (like Ollama via Docker)
</p>
<p>
- **Vector Data Support:** Built-in code for processing, embedding, and caching data, using either local vector stores or cloud services like **Azure AI Search** and **Qdrant**
</p>
<p>
- **Modern .NET Abstractions:** Projects are built using the official `Microsoft.Extensions.AI` packages, making it simple to plug in custom behaviors or C# functions for the AI to execute
</p>

<p>

	Installation:
	dotnet new install Microsoft.Extensions.AI.Templates
	dotnet new install Microsoft.McpServer.ProjectTemplates
</p>

## Why Qdrant?

- Vector search engine, [erfect for storing emeddings from text, images or other high-dimensional data
- Enable semantic searches and is strightforward to setup in .NET Aspire with **Aspire.Hosting.Qdrant** package.
 

**Microsoft.Extensions.VectorData.Abstractions**
   - This gives us common interfaces : Abstract CRUD on vector data, standardized to connect VectorDBs (Chroma, Qdrant, Pinecode, Weaviate)
   - Supports Vector and Text Search : Unified method for inserting embedding, High-level search functions

   - Decouple your Application from Vendor SDKs : App code remain flexible, Swap underlying vector store implementations (local or could-based) with minimal changes.
   - **The Foundation :** Microsoft.Extensions.VectorData : It is like Entity Framework for vector. Unified way to perform CRUD and search operations
   - **Implementation - Semaintc Kernal Connectors  :**  Simantic Kernal team provides a connector for Qdtrant, another for Chroma, another for Pinecone ..
   - **Integration - Aspire Client Library :** Aspire.Qdrant.Client, makes dependency injection and configuration effortless.

## Required Packages for .Net Aspire and Qdrant:

- **Aspre hosting Integration :** Aspire.Qdrant.Client
- **Microsoft.SemanticKernel.Connectors.Qdrant :** Actual Qdrant driver from Semantic Kernal team that works with the VectorData abstractions
- ***Note:***  If we notice we don't install Microsoft.Extensions.VectorData.Abstractions explicitly because Microsoft.SemanticKernel.Connectors.Qdrant brings it automatically



  ## Generative AI Vs Agentic AI

Generative AI creates content, whereas Agentic AI drives action. Generative AI is reactive—waiting for prompts to draft emails, write code, or generate images. Agentic AI is proactive—it independently sets goals, plans multi-step tasks, and uses external tools to execute workflows with minimal human oversight

<img width="609" height="434" alt="image" src="https://github.com/user-attachments/assets/453e69d0-b164-4d89-aeac-dd42e289a4ea" />

How They Work Together

Generative AI is essentially the brain or the "cognitive engine" inside an Agentic system. When an Agentic AI needs to perform a complex task, it often utilizes a GenAI model to generate the actual text, read documents, or draft emails.

For example, a **Generative AI** tool like ChatGPT can write a great, empathetic follow-up email when prompted. However, an **Agentic AI** system connects to your CRM, checks which clients are overdue for a meeting, autonomously plans the schedule, drafts the emails using a GenAI model, sends the messages, and updates the database—all without requiring a human to trigger every step.

**When to Use Which**

-   Use **Generative AI** when the final deliverable is content that requires human review and editing (e.g., blog posts, translation, structured summaries, or creative brainstorming).
-   Use **Agentic AI** when the desired outcome is a completed action or process across multiple platforms (e.g., updating customer tickets, reordering stock, booking travel, or resolving IT requests)


<u>## Notes :</u> 
## 1. Update Aspire version:

- We need to have install Aspire CLI to upgrade Aspire version <br/>
			<i>npm install -g @microsoft/aspire-cli</i> <br/>
- Now we can Upgrade Aspire version globally <br/>
			<i>aspire update --self </i><br/>
- If you want to upgrade existing Aspire project to latest version. Open terminal and goto project directory and then<br/>
  			<i> aspire update </i> <br/>
Then We need to upgrade all Aspire templates <br/>
			<i>dotnet new install Aspire.ProjectTemplates </i> <br/>

## 2. Update HTTPClient Resilience timeout in Api Call.
<pre>
public static class OllamaResilienceHandlerExtensions
{
    public static IServiceCollection AddOllamaResilienceHandler(this IServiceCollection services)
    {
        services.ConfigureHttpClientDefaults(httpClientBuilder =>
        {
			#pragma warning disable EXTEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            httpClientBuilder.RemoveAllResilienceHandlers();
			#pragma warning restore EXTEXP0001 // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
            httpClientBuilder.AddStandardResilienceHandler(config =>
            {
                config.AttemptTimeout.Timeout = TimeSpan.FromMinutes(5);  //Timeout for each attempt
                config.CircuitBreaker.SamplingDuration = TimeSpan.FromMinutes(10); // 
                config.TotalRequestTimeout.Timeout = TimeSpan.FromMinutes(10);
            });

        });
        return services;
    }
}
	
</pre>



## RAG (Retrieval Agumented Generation)
### Udemy Cource : Url : https://www.udemy.com/course-dashboard-redirect/?course_id=7019363
### Github Url : https://github.com/vash-labs/practical-rag-dotnet



