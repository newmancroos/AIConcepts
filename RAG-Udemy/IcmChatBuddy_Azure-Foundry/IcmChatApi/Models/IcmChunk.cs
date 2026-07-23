using Microsoft.Extensions.VectorData;
using System.Text.Json.Serialization;

namespace IcmChatApi.Models;

public class IcmChunk
{
    public const int VectorDimension = 384;
    public const string VectorDistanceFunction = DistanceFunction.CosineDistance;

    [VectorStoreKey(StorageName = "key")]
    [JsonPropertyName("key")]
    public required string Key { get; set; }
    [VectorStoreData(StorageName ="content")]
    [JsonPropertyName("content")]
    public required string Content { get; set; }
    [VectorStoreData(StorageName = "context")]
    [JsonPropertyName("context")]
    public string? Context { get; set; }
    [VectorStoreData(StorageName = "documentid")]
    [JsonPropertyName("documentid")]
    public required string  DocumentId { get; set; }

    [VectorStoreVector(VectorDimension, StorageName ="embedding")]   //, DistanceFunction = VectorDistanceFunction)   -- Removed for Azure
    [JsonPropertyName("embedding")]
    public float[]? Embedding { get; }  // Changed from string to float[] for azure
}
