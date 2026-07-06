var builder = DistributedApplication.CreateBuilder(args);

var ollama = builder.AddOllama("ollama")
    .WithDataVolume();

var chatModel = ollama.AddModel("chat", "llama3.2");
var embeddings =  ollama.AddModel("embeddings", "all-minilm");

var vectorStore = builder.AddSqlite("vector-store").WithSqliteWeb();

//Testing Ollama-lamma3.2 model, we can use GithubWebUi

//builder.AddContainer("open-webui", "ghcr.io/open-webui/open-webui", "main")
//    .WithHttpEndpoint(port: 3000, targetPort: 8080, name: "http")
//    .WithEnvironment("OLLAMA_BASE_URL", ollama.GetEndpoint("http"))
//    .WithLifetime(ContainerLifetime.Persistent)
//    .WaitFor(ollama);

builder.AddProject<Projects.IcmChatApi>("icmchatapi")
    .WithReference(chatModel)
    .WaitFor(chatModel);

builder.AddProject<Projects.IngestionService>("ingestionservice")
    .WithReference(embeddings)
    .WithReference(vectorStore)
    .WaitFor(embeddings)
    .WaitFor(vectorStore);

builder.Build().Run();
