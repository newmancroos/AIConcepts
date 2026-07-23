using Azure.Search.Documents.Indexes;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;

namespace IngestionService;

public static class Extensions
{
    public static IServiceCollection AddIcmAzureSearchVectorStore(this IServiceCollection services)
    {
        services.AddSingleton<VectorStore>(sp =>
        {
            var indexClient = sp.GetRequiredService<SearchIndexClient>();                                      // When we use Ollama embedding builder.AddOllamaApiClient("embeddings")
            return new AzureAISearchVectorStore(indexClient,new AzureAISearchVectorStoreOptions()              // .AddEmbeddingGenerator()
            {                                                                                                  // .UseOpenTelemetry(configure: c => c.EnableSensitiveData = builder.Environment.IsDevelopment());
                EmbeddingGenerator = sp.GetRequiredService<IEmbeddingGenerator<string, Embedding<float>>>(),   // Ingection works but for Azure AI we need to specifically mention it. so the 2dn parameter.

            });                                                
                                                               
                                                               
                                                               
        });
        return services;
    }
}
