
using IcmChatApi;
using IcmChatApi.Models;
using Microsoft.Extensions.AI;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();
var sqliteConnectionString = builder.Configuration.GetConnectionString("vector-store") ?? throw new InvalidOperationException("Failed : Vector database connection");
builder.Services.AddSqliteCollection<string, IcmChunk>("data-icm-chunks", sqliteConnectionString); // Make a model for our collection
builder.AddOllamaApiClient("chat")
    .AddChatClient()
    .UseFunctionInvocation()
    .UseOpenTelemetry(configure: c => c.EnableSensitiveData = builder.Environment.IsDevelopment());


builder.AddOllamaApiClient("embeddings")
    .AddEmbeddingGenerator()
    .UseOpenTelemetry(configure: c => c.EnableSensitiveData = builder.Environment.IsDevelopment());

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