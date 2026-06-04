
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.ClientModel;

IConfigurationRoot config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var credentials = new ApiKeyCredential(config["GitHubModels:Token"] ?? throw new InvalidOperationException());

var options = new OpenAIClientOptions()
{
    Endpoint= new Uri("https://models.github.ai/inference")
};

IChatClient client = new OpenAIClient(credentials, options).GetChatClient("openai/gpt-4o-mini").AsIChatClient();

//user prompts
var promptDescribe = "Describe the image";
var promptAnalyze = "How many red cars are in the picture? and what other car colors are there?";

//prompts

var systemPrompt = "You are a useful assitant for describes images using a direct style.";
var userPrompt = promptAnalyze;

List<ChatMessage> messages = new List<ChatMessage>()
{
    new ChatMessage(ChatRole.System, systemPrompt),
    new ChatMessage(ChatRole.User, userPrompt)
};

//read the image bytes, create a new image content part and add it to the messages

var imageFileName = "cars.png";
string image = Path.Combine(Directory.GetCurrentDirectory(), "images", imageFileName);

AIContent aic = new DataContent(File.ReadAllBytes(image), "image/png");

var message = new ChatMessage(ChatRole.User, [aic]);
messages.Add(message);

//send wthe message to the assistant
var response = await client.GetResponseAsync(messages);  

Console.WriteLine($"Prompt: {userPrompt}");
Console.WriteLine($"Image: {imageFileName}");
Console.WriteLine($"Response: {response.Messages[0]}");



