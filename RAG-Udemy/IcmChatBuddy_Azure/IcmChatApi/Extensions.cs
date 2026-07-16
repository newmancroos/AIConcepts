using Azure.Search.Documents.Indexes;
using IcmChatApi.Models;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using Microsoft.SemanticKernel.Connectors.AzureAISearch;
using System.Runtime.CompilerServices;

namespace IcmChatApi;

public static class Extensions
{
    public static IServiceCollection AddIcmAzureSearchCollection(this IServiceCollection services, string name)
    {
        services.AddSingleton<VectorStoreCollection<string, IcmChunk>>(sp =>   //Replacing AddSqliteCollection dependency with AddSingleton for Azure Search collection
        {
            //Here we need to return Azure Collection, we can use Azure Search SDK to create a collection and return it. For now, we will return null.
            //Install Nuget package Microsoft.SemanticKernel.Connectors.AzureAISearch to use Azure Search SDK

            var indexClient = sp.GetRequiredService<SearchIndexClient>();
            return new AzureAISearchCollection<string, IcmChunk>(indexClient, name, new AzureAISearchCollectionOptions
            { 
                EmbeddingGenerator= sp.GetRequiredService<IEmbeddingGenerator>()
            });
        });

        return services;

    }
}
