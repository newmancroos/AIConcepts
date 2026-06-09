using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;

namespace Catalog.Services;

public class ProductAIService(IChatClient chatClient, 
    IEmbeddingGenerator<string, Embedding<float>> embeddingGenerator,
    VectorStoreCollection<ulong, ProductVector> productVectorCollection,
    CatalogDbContext dbContext
    )
{
    public async Task<string> SupportAsync(string userQuery, CancellationToken cancellationToken = default)
    {
        var products = await dbContext.Products
            .AsNoTracking()
            .Select(p => new { p.Id, p.Name, p.Price })
            .ToListAsync(cancellationToken);

        string productCatalog = products.Count == 0 ? "- (No products available)"
            : string.Join("\n", products.Select(p => $" -Id:{p.Id} Name:\"{p.Name}\" Price:{p.Price:C}"));


        // If unrelated say exactly: "I only answer questions about outdoor camping products."
        var systemPrompt = $"""
            You are a helpful assistant for an outdoor camping products store.
            Rules:
            1. Only answer questions related to outdoor camping or the product catalog.
            2. Be concise and a little funny (light humor).
            3. If you don't know, reply exactly: "I don't know that."
            4. Do not store memory of the conversation.
            5. When appropriate (most user questions), end with ONE relevant product recommendation from the catalog below.
               - Pick the product that best matches the user's intent; if none clearly match, pick a random one.
               - Format the recommendation on a new final line as:
                 Recommendation: <Product Name> - <Price>
            6. Do NOT invent products not in the catalog.

            Product Catalog:
            {productCatalog}
            """;

        var chatHistory = new List<ChatMessage>
        {
            new ChatMessage(ChatRole.System, systemPrompt),
            new ChatMessage(ChatRole.User, userQuery)
        };

        var response = await chatClient.GetResponseAsync(chatHistory, cancellationToken: cancellationToken);

        return response.Text ?? "No description available.";
    }

    private async Task InitEmbeddingsAsync()
    { 
        await productVectorCollection.EnsureCollectionExistsAsync();
        var products = await dbContext.Products
            .AsNoTracking()
            .ToListAsync();

        foreach (var product in products)
        { 
            var productInfo = $"[{product.Name}] is a product that costs [{product.Price}] and is described as [{product.Description}]";
            var productVector = new ProductVector
            {
                Id = (ulong)product.Id,
                Name = product.Name,
                Description = product.Description,
                Price =(float)product.Price,
                ImageUrl = product.ImageUrl,
                Vector = await embeddingGenerator.GenerateVectorAsync(productInfo)
            };
            await productVectorCollection.UpsertAsync(productVector);
        }
    }
    public async Task<IEnumerable<Product>> SearchProductsAsync(string query)
    {
        //step1 : Use the IEmbeddingGenerator to turn the user's query into a vector.
        //step2 : Use the IVectorStore to search Qdrant for the most similar product vectors.
        //step3 : Get the IDs of matching products from the search results.
        //step4 : Retrive the full product details from our main Postgres database for those IDs
        //step5 : Return the matching products to the user.

        if(!await productVectorCollection.CollectionExistsAsync())
        {
            await InitEmbeddingsAsync();
        }

        var queryEmbedding = await embeddingGenerator.GenerateVectorAsync(query);

        var result = productVectorCollection.SearchAsync(queryEmbedding, 1);

        List<Product> products = new List<Product>();

        await foreach(var searchResult in result)
        {
            products.Add(new Product
            {
                Id = (int)searchResult.Record.Id,
                Name = searchResult.Record.Name,
                Description = searchResult.Record.Description,
                Price =(decimal)searchResult.Record.Price,
                ImageUrl = searchResult.Record.ImageUrl
            });
        }

        return  products;
    }
}
