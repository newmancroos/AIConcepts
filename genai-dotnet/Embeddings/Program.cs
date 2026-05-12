
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Configuration;
using OpenAI;
using System.ClientModel;
using System.Numerics.Tensors;

IConfigurationRoot config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

var credentials = new ApiKeyCredential(config["GitHubModels:Token"] ?? throw new InvalidOperationException());


var options = new OpenAIClientOptions()
{
    Endpoint = new Uri("https://models.github.ai/inference")
};

//Create Chat Client
IChatClient client = new OpenAIClient(credentials, options).GetChatClient("openai/gpt-4o-mini").AsIChatClient();

//Create an embedding generator (text-embedding-3-small is an example
IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator = new OpenAIClient(credentials,options).GetEmbeddingClient("text-embedding-3-small").AsIEmbeddingGenerator();


//1. Generate a single embedding
//var embedding = await embeddingGenerator.GenerateVectorAsync("Hello world!");

//Console.WriteLine($"Embedding dimensions : {embedding.Span.Length}");

//foreach (var value in embedding.Span)
//{
//    Console.Write("{0:0.00}",value);
//}


//2. Compare multiple embeddings using cosine similarity

var catVector = await embeddingGenerator.GenerateVectorAsync("cat");
var dogVector = await embeddingGenerator.GenerateVectorAsync("dog");
var kittenVector = await embeddingGenerator.GenerateVectorAsync("kitten");

Console.WriteLine($"cat-dog similarity : {TensorPrimitives.CosineSimilarity(catVector.Span, dogVector.Span):F2}");
Console.WriteLine($"cat-kitten similarity : {TensorPrimitives.CosineSimilarity(catVector.Span, kittenVector.Span):F2}");
Console.WriteLine($"dog-kitten similarity : {TensorPrimitives.CosineSimilarity(dogVector.Span, kittenVector.Span):F2}");

