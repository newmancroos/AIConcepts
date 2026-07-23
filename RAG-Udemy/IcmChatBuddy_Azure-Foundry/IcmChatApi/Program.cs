
using IcmChatApi;
using IcmChatApi.Models;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();



builder.AddOllamaApiClient("embeddings")
    .AddEmbeddingGenerator()
    .UseOpenTelemetry(configure: c => c.EnableSensitiveData = builder.Environment.IsDevelopment());

var useAzure = builder.Configuration.GetValue<bool>("useAzure");

////Commented due to using AzureSearchClient instead of SqliteCollection, we can use SqliteCollection for local development and AzureSearchClient for production

if (useAzure)
{
    // To add the vactor database in Azure we need to coded it as extension, AddSqliteCollection is the inbuild extension for Sqlite but azure weed to write
    builder.AddAzureSearchClient("azure-search");
    builder.Services.AddIcmAzureSearchCollection("data-icm-chunks").AddOpenTelemetry();   // Add Microsoft.SemanticKernel.Connectors.AzureAISearch package to use Azure Search SDK, and add OpenTelemetry for Azure Search client
    //Install Aspire.Azure.AI.Inference it is more generaric but also we can use Aspire.Azure.AI.OpenAI
    builder.AddAzureChatCompletionsClient("foundry").AddChatClient("gpt-5.2-chat") //name of the model deployment name in the foundry, we can also use "gpt-5.2-chat" or "g
        .UseFunctionInvocation()
        .UseDistributedCache()   //Adding caching for chat client, need to register IDistributed cache in the service collection, we can use Redis or Memory cache
        .UseOpenTelemetry(configure: c => c.EnableSensitiveData = builder.Environment.IsDevelopment());   //Adding Open Telemetriy for development environment, we can disable it in production environment
}
else
{
    //Moved here because UseAzure uses Azure Foundry as Chat Model
    builder.AddOllamaApiClient("chat")
        .AddChatClient()
        .UseFunctionInvocation()
        .UseDistributedCache()   //Adding caching for chat client, need to register IDistributed cache in the service collection, we can use Redis or Memory cache
        .UseOpenTelemetry(configure: c => c.EnableSensitiveData = builder.Environment.IsDevelopment());   //Adding Open Telemetriy for development environment, we can disable it in production environment


    var sqliteConnectionString = builder.Configuration.GetConnectionString("vector-store") ?? throw new InvalidOperationException("Failed : Vector database connection");
    builder.Services.AddSqliteCollection<string, IcmChunk>("data-icm-chunks", sqliteConnectionString); // Make a model for our collection
}

builder.AddRedisDistributedCache("cache");



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddOllamaResilienceHandler();

var app = builder.Build();

app.MapDefaultEndpoints();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.MapOpenApi();
    //app.UseSwaggerUi(options =>
    //{
    //    options.DocumentPath = "/openapi/v1.json";
    //});

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();