using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using VibeCast.Application.Episodes;
using VibeCast.Domain.Episodes;
using VibeCast.Infrastructure.Data;

namespace VibeCast.Infrastructure.Episodes;

public class EpisodeService (IDbContextFactory<VibeCastDbContext> dbContextFactory): IEpisodeService
{
    public async Task<Guid> CreateAsync(CreateEpisodeRequest request, string ownerId, CancellationToken cancellationToken=default)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (string.IsNullOrWhiteSpace(ownerId))
        {
            throw new ArgumentNullException("An authenticated owner is required.");
        }

        Episode episode = Episode.Create(
            title: request.Title,
            description: request.Description,
            targetAudience: request.TargetAudience,
            objective: request.Objective,
            tone: request.Tone,
            language: request.Language,
            plannedPublishDate: request.PlannedPublishDate,
            ownerId: ownerId
            );

        await using VibeCastDbContext dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);
        dbContext.Episodes.Add(episode);
        await dbContext.SaveChangesAsync(cancellationToken);

        return episode.Id;

    }

   public async  Task<EpisodeDetails> GetAsync(Guid episodeId, string ownerId, CancellationToken cancellationToken = default)
   {
        if (episodeId == Guid.Empty)
        {
            throw new ArgumentException("A Valid episode identifier is required.");
        }
        if (string.IsNullOrWhiteSpace(ownerId))
        {
            throw new ArgumentException("An authenticated owner is required.", nameof(ownerId));
        }


        await using VibeCastDbContext dbContext = await dbContextFactory.CreateDbContextAsync(cancellationToken);

        Episode? episode =
        await dbContext.Episodes
            .AsNoTracking()
            .SingleOrDefaultAsync(
                item =>
                    item.Id == episodeId &&
                    item.OwnerId == ownerId,
                cancellationToken);

        if (episode is null)
        {
            return null;
        }

        //EpisodePlanningResult? acceptedPlan = CreateAcceptedPlan(episode);

        return new EpisodeDetails(
            Id: episode.Id,
            Title: episode.Title,
            Description: episode.Description,
            TargetAudience: episode.TargetAudience,
            Objective: episode.Objective,
            Tone: episode.Tone,
            Language: episode.Language,
            PlannedPublishDate: episode.PlannedPublishDate,
            Status: episode.Status,
            CreatedAtUtc: episode.CreatedAtUtc,
            UpdatedAtUtc: episode.UpdatedAtUtc);
            //AcceptedPlan: acceptedPlan);
    }
}
