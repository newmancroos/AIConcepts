using IngestionService;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddOllamaApiClient("embeddings").AddEmbeddingGenerator();

var sqliteConnectionString=  builder.Configuration.GetConnectionString("vector-store");

builder.Services.AddSqliteVectorStore(_ => sqliteConnectionString ?? throw new InvalidOperationException("Connection string not found"));



builder.Services.AddHostedService<Worker>();




var host = builder.Build();
host.Run();
