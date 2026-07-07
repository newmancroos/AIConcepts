using IngestionService;
using Microsoft.Extensions.AI;

var builder = Host.CreateApplicationBuilder(args);

builder.AddServiceDefaults();
builder.AddOllamaApiClient("embeddings")
    .AddEmbeddingGenerator()
    .UseOpenTelemetry(configure: c => c.EnableSensitiveData = builder.Environment.IsDevelopment());
//Enable open telemetry for development environment, we can disable it in production environment
// We can enable application insight by installing Azure.Monitor.OpenTelemetry.AspNetCore
//builder.Services.AddOpenTelemetry().UseAzureMonitor();
//Copy App Insight connection string and set it in the environment variable "APPLICATIONINSIGHTS_CONNECTION_STRING" or in appsettings.json

var sqliteConnectionString =  builder.Configuration.GetConnectionString("vector-store");

builder.Services.AddSqliteVectorStore(_ => sqliteConnectionString ?? throw new InvalidOperationException("Connection string not found"));



builder.Services.AddHostedService<Worker>();




var host = builder.Build();
host.Run();
