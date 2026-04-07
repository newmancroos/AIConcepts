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

