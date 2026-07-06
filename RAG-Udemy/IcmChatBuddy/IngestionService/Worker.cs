using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.DataIngestion;
using Microsoft.Extensions.DataIngestion.Chunkers;
using Microsoft.Extensions.VectorData;
using Microsoft.ML.Tokenizers;
using System.Diagnostics;

namespace IngestionService;

public class Worker(ILoggerFactory loggerFactory, ILogger<Worker> logger, IEmbeddingGenerator<string,Embedding<float>> embeddingGenerator, VectorStore vectorStore) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        const string trackingFilePath = "tracking.txt";

        var directoryInfo = new DirectoryInfo("icm_incident_dataset");

        await File.Create(trackingFilePath).DisposeAsync();


        while (!stoppingToken.IsCancellationRequested)
        {
            var processedFiles = (await File.ReadAllLinesAsync(trackingFilePath, stoppingToken)).ToHashSet();

            var filesToProcess = directoryInfo.EnumerateFiles("*.md").Where(files => !processedFiles.Contains(files.FullName));


            if (logger.IsEnabled(LogLevel.Information))
            {
                logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                logger.LogInformation("Files to Process : {files}", string.Join(", ", filesToProcess.Select(x => x.Name)));
            }



            using var vectorStoreWriter = new VectorStoreWriter<string>(vectorStore,384, new VectorStoreWriterOptions { 
                CollectionName = "data-icm-chunks",
                DistanceFunction = DistanceFunction.CosineDistance,
                IncrementalIngestion = true

            });  //Microsoft.SematicKernel.Connectors.sqliteVec. Vector count for all-minilm is 384 (search in google)

            //Ingestion Pipeline
            IngestionPipeline<string> ingestionPipeline = new IngestionPipeline<string>(
                reader:new IcmReader(), 
                chunker: new SemanticSimilarityChunker(embeddingGenerator, new IngestionChunkerOptions(TiktokenTokenizer.CreateForModel("gpt-4o"))),   //*****Get the model name from TiktokenTokenizer base class
                writer: vectorStoreWriter, 
                loggerFactory: loggerFactory);


            await foreach (var result in ingestionPipeline.ProcessAsync(filesToProcess, stoppingToken))
            {
                if (!result.Succeeded)
                { 
                    logger.LogError("Failed to process file : {}", result.DocumentId);
                }

            }

            await File.AppendAllLinesAsync(trackingFilePath, filesToProcess.Select(x => x.FullName), stoppingToken);


            await Task.Delay(1000, stoppingToken);
        }
    }

    public class IcmReader : IngestionDocumentReader
    {

        private readonly MarkdownReader _markdownReader = new();
        public override async  Task<IngestionDocument> ReadAsync(Stream source, string identifier, string mediaType, CancellationToken cancellationToken = default)
        {
            //Debug.WriteLine(identifier);
            //Debug.WriteLine(mediaType);
            return await _markdownReader.ReadAsync(source, identifier, mediaType, cancellationToken);
        }
    }
}
