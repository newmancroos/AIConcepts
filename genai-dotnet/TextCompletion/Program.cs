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

string prompt = "What is AI? explain max 200 words.";

Console.WriteLine($"User >>> {prompt}");

var responseStream = client.GetStreamingResponseAsync(prompt);

await foreach (var message in responseStream)
{ 
    Console.Write(message);
}

Console.ReadLine();

#endregion