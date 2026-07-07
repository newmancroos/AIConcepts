using Microsoft.Extensions.VectorData;

namespace IcmChatApi.Models;

public class IcmChunk
{
    public const int VectorDimension = 384;
    public const string VectorDistanceFunction = DistanceFunction.CosineDistance;

    [VectorStoreKey]
    public required string Key { get; set; }
    [VectorStoreData]
    public required string Content { get; set; }
    [VectorStoreData]
    public string? Context { get; set; }
    [VectorStoreData]
    public required string  DocumentId { get; set; }

    [VectorStoreVector(VectorDimension, DistanceFunction = VectorDistanceFunction)]
    public string? Embedding { get; }  // This should be float but we configured Embedding Provider handle it in the host
}
