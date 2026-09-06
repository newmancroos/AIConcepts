namespace VibeCast.Application.Episodes;

public interface IEpisodeService
{
    Task<Guid> CreateAsync(
        CreateEpisodeRequest request,
        string ownerId,
        CancellationToken cancellationToken = default
        );

    Task<EpisodeDetails> GetAsync(
        Guid episodeId,
        string ownerId,
        CancellationToken cancellationToken = default
        );
}
