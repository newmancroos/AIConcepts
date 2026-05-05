using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.ClientModel;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var credential = new ApiKeyCredential(config["GitHubModels:Token"] ?? throw new ArgumentNullException("GitHubModels:Token"));

var options = new OpenAIClientOptions()
{
    Endpoint = new Uri("https://models.github.ai/inference")
};

//Create chat client 
IChatClient client = new OpenAIClient(credential, options).GetChatClient("openai/gpt-4o-mini").AsIChatClient();


#region Basic Completion
////Send promt and get response

////var response = await client.GetResponseAsync("What is AI? explain max 20 words.");
////Console.WriteLine(response);
////Console.ReadLine();

//string prompt = "What is AI? explain max 20 words.";

//Console.WriteLine($"User >>> {prompt}");

//ChatResponse response = await client.GetResponseAsync(prompt);
//Console.WriteLine($"AI >>> {response}");
//Console.WriteLine($"Toekn Used: In= {response.Usage?.InputTokenCount}, Out= {response.Usage?.OutputTokenCount}");
//Console.ReadLine();
#endregion

#region Streamimg

//string prompt = "What is AI? explain max 200 words.";

//Console.WriteLine($"User >>> {prompt}");

//var responseStream = client.GetStreamingResponseAsync(prompt);

//await foreach (var message in responseStream)
//{ 
//    Console.Write(message);
//}

//Console.ReadLine();

#endregion

#region Classification

//var classificationPrompt = """
//    Please classify the following sentences into categories:
//    - 'complaint',
//    - 'suggestions',
//    - 'praise',
//    - 'other'

//    1) "I love the new layout."
//    2) "You should add a night mode."
//    3) "When I try to log in, it keeps failing."
//    4) "This app is decent."
//    """;

//Console.WriteLine($"User >>> {classificationPrompt}");

//ChatResponse classificationResponse = await client.GetResponseAsync(classificationPrompt);

//Console.WriteLine($"assistant  >>>\n {classificationResponse}");

#endregion

#region Summarization

//var summaryPrompt= """
//    Please summarize the following text in one sentence:
//    "Artificial Intelligence (AI) is a branch of computer science that focuses on creating machines capable of performing tasks that typically require human intelligence. These tasks include learning, reasoning, problem-solving, perception, and language understanding. AI systems can be categorized into narrow AI, which is designed for specific tasks, and general AI, which has the potential to perform any intellectual task that a human can do. The development of AI has led to significant advancements in various fields such as healthcare, finance, and transportation."
//    """;

//ChatResponse summaryResponse = await client.GetResponseAsync(summaryPrompt);

//Console.WriteLine($"assistant  >>>\n {summaryResponse}");

#endregion

#region Sentiment Analysis
var analysisPrompt = """
    You will analyze the sentiment of the following product reviews. Each line is its own review. Output the sentiment of each review in a bulleted list and then provide a generate sentiment of all reviews.
    
    I bought this product and it's amazing. I love it!
    This product is terrible.  I hate it.
    I'm not sure about this product. It's okay.
    I found this product based on the other reviews. It worked for a bit, and then it didn't.
    """;

ChatResponse analysisResponse = await client.GetResponseAsync(analysisPrompt);

Console.WriteLine($"assistant  >>>\n {analysisResponse}");

#endregion