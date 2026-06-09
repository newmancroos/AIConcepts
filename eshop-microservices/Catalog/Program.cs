
using Microsoft.Extensions.AI;
using OpenAI;
using System.ClientModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.AddServiceDefaults();

builder.AddNpgsqlDbContext<CatalogDbContext>(connectionName: "catalogdb");

builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<ProductAIService>();

//Add AI Chat client

var credentials = new ApiKeyCredential(builder.Configuration["GitHubModels:Token"]) ?? throw new InvalidOperationException("Missing configuration: GitHubModels:Token");
var options = new OpenAIClientOptions
{
    Endpoint = new Uri("https://models.github.ai/inference")
};

var openAIClient = new OpenAIClient(credentials, options);
IChatClient claint = openAIClient.GetChatClient("openai/gpt-4o-mini").AsIChatClient();

var embeddingGenerator = openAIClient.GetEmbeddingClient("openai/text-embedding-3-small").AsIEmbeddingGenerator();
builder.Services.AddChatClient(claint);
builder.Services.AddEmbeddingGenerator(embeddingGenerator);




//Add vector db search operations
builder.AddQdrantClient("vectordb");
builder.Services.AddQdrantCollection<ulong, ProductVector>("product-vectors");


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseMigration();

app.MapProductEndpoints();

app.Run();
