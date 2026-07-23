using Microsoft.Extensions.VectorData;

var builder = DistributedApplication.CreateBuilder(args);


//Add Parameters
bool useAzuer = true;

string vectorFuntion = useAzuer ? DistanceFunction.CosineSimilarity : DistanceFunction.CosineDistance;   //Sqlite support  DistanceFunction.CosineDistance but Azure supports DistanceFunction.CosineSimilarity
var cache = builder.AddRedis("cache").WithDbGate();      //View redis



var ollama = builder.AddOllama("ollama")
    .WithDataVolume();


var embeddings = ollama.AddModel("embeddings", "all-minilm");

if (useAzuer)
{
    // Add Nuget package Aspire.Hosting.Azure.AIFoundry for chat model
    var existingAzureSearch = builder.AddParameter("existingAzSearch");
    var existingRg = builder.AddParameter("existingIcmBuddyRg");
    var azureSearch = builder.AddAzureSearch("azure-search").AsExisting(existingAzureSearch, existingRg);   //AsExisting is used to connect to an existing Azure Search service

    var existingFoundry = builder.AddParameter("existingFoundry");
    var foundry = builder.AddAzureAIFoundry("foundry").AsExisting(existingFoundry, existingRg);   //AsExisting is used to connect to an existing Azure AI Foundry service

    builder.AddProject<Projects.IcmChatApi>("icmchatapi")
    .WithReference(foundry)  // Previously we used Ollama chat model but now we are using Azure AI Foundry chat model
    .WithReference(embeddings)
    .WithReference(cache)
    .WithReference(azureSearch)   // Added for Azure
    .WithEnvironment("useAzure", useAzuer.ToString())
    .WaitFor(foundry)
    .WaitFor(embeddings)
    .WaitFor(cache)
    .WaitFor(azureSearch);   // Added for Azure

    builder.AddProject<Projects.IngestionService>("ingestionservice")
        .WithReference(embeddings)
        .WithReference(azureSearch)   // Added for Azure
        .WithEnvironment("vectorFunction", vectorFuntion)  // Creating Environment variable so we can access it from IngestionService
        .WithEnvironment("useAzure", useAzuer.ToString())
        .WaitFor(embeddings)
        .WaitFor(azureSearch);   // Added for Azure
    builder.Build().Run();

}
else
{
    var vectorStore = builder.AddSqlite("vector-store").WithSqliteWeb();
    var chatModel = ollama.AddModel("chat", "llama3.2");

    builder.AddProject<Projects.IcmChatApi>("icmchatapi")
    .WithReference(chatModel)
    .WithReference(vectorStore)
    .WithReference(embeddings)
    .WithReference(cache)
    .WaitFor(chatModel)
    .WaitFor(vectorStore)
    .WaitFor(embeddings)
    .WaitFor(cache);

    builder.AddProject<Projects.IngestionService>("ingestionservice")
        .WithReference(embeddings)
        .WithReference(vectorStore)
        .WithEnvironment("vectorFunction", vectorFuntion)  // Creating Environment variable so we can access it from IngestionService
        .WaitFor(embeddings)
        .WaitFor(vectorStore);
    builder.Build().Run();

}


