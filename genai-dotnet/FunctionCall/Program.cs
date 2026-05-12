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
IChatClient client = new ChatClientBuilder( new OpenAIClient(credential, options).GetChatClient("openai/gpt-4o-mini").AsIChatClient())
    .UseFunctionInvocation()
    .Build();

var chatOptions = new ChatOptions
{
    Tools = [
        AIFunctionFactory.Create((string location, string unit)=>
    {
        //Here we can call our own API end point
        // This is same as function call using Semantic agent
        var temperature = Random.Shared.Next(5, 20);
        var conditions = Random.Shared.Next(0, 1) == 0 ? "sunny" : "rainy";

        return $"The waether is {temperature} degrees {unit} and {conditions} in {location}";

    },
    "get_current_weather",
    "Get the current weather in a given location"
    )
    // AIFunctionFactory.Create((string location, string unit)=>
    //{
    //    //Here we can call our own API end point
    //    var temperature = Random.Shared.Next(5, 20);
    //    var conditions = Random.Shared.Next(0, 1) == 0 ? "sunny" : "rainy";

    //    return $"The waether is {temperature} degrees {unit} and {conditions} in {location}";

    //})
    ]
};



List<ChatMessage> chatHistory = [
    new ChatMessage(ChatRole.System, """
         You are a hiking enthusiast who helps people discover fun hikes in their area.
        You are upbeat and firendly.
        """)];


// Weather conersation relevent to the registered function
chatHistory.Add(new ChatMessage(ChatRole.User, """
    I live in Istanbul and I'm looking for a moderate intensity hike. What's the current waether like?
    """));

Console.WriteLine($"{chatHistory.Last().Role}>>> {chatHistory.Last()}");

ChatResponse response = await client.GetResponseAsync(chatHistory, chatOptions);

chatHistory.Add(new ChatMessage(ChatRole.Assistant, response.Text));

Console.WriteLine($"{chatHistory.Last().Role}>>> {chatHistory.Last()}");

