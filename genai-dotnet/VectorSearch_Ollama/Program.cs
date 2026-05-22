//Goto Ollama.com/library/all-minilm and download it
// OR in the interactive terminal write "ollama pull all-minilm" to download the model

// We suppose to iuse Microsoft.Extensions.AI.Ollama for embedding when we use Ollama models, but it is deprecated and not working.
//Embedding generator is the different from Open Ai and Ollama
//Odrant or Chroma are Vector databases


// Microsoft.Extensions.VectorData.Abstractions - Allows you to write your search and data storage logic
// against a standard interface, making it easy to sweap the underlying vector database later.


using Microsoft.Extensions.AI;
using Microsoft.SemanticKernel.Connectors.InMemory;
using OllamaSharp;
using VectorSearch_Ollama;

IEmbeddingGenerator<string, Embedding<float>> generator = new OllamaApiClient(new Uri("http://localhost:11434"), "all-minilm");


// Create and populate the vector store
var vectorStore = new InMemoryVectorStore();

var moviesStore = vectorStore.GetCollection<int, Movie>("movies");

await moviesStore.EnsureCollectionExistsAsync();

foreach (var movie in MovieData.Movies)
{
    // generate the embedding vector for the movie description
    movie.Vector = await generator.GenerateVectorAsync(movie.Description);

    // add the overall movie to the in-memory vector store's movie collection
    await moviesStore.UpsertAsync(movie);
}

//1-Embed the user’s query
//2-Vectorized search
//3-Returns the records

// generate the embedding vector for the user's prompt
//var query = "I want to see family friendly movie";
var query = "A science fiction movie about space travel";
var queryEmbedding = await generator.GenerateVectorAsync(query);

// search the knowledge store based on the user's prompt
var searchResults = moviesStore.SearchAsync(queryEmbedding, top: 2);

// see the results just so we know what they look like
await foreach (var result in searchResults)
{
    Console.WriteLine($"Title: {result.Record.Title}");
    Console.WriteLine($"Description: {result.Record.Description}");
    Console.WriteLine($"Score: {result.Score}");
    Console.WriteLine();
}