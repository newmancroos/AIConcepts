
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

IChatClient claint = new OpenAIClient(credentials, options).GetChatClient("openai/gpt-4o-mini").AsIChatClient();

builder.Services.AddChatClient(claint);


var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapDefaultEndpoints();

app.UseHttpsRedirection();

app.UseMigration();

app.MapProductEndpoints();

app.Run();
