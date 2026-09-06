using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.Logging;
using VibeCast.Application;
using VibeCast.Application.Episodes;

namespace VibeCast.Infrastructure.AI;

public class FoundryEpisodePLanningService(
    IChatClient chatClient,
    ILogger<FoundryEpisodePLanningService> logger
    ) : IEpisodePlanningService
{
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public async Task<EpisodePlanningResult> GenerateAsync(GenerateEpisodePlanRequest request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.EpisodeId == Guid.Empty)
        {
            throw new ArgumentException(
                "A valid episode identifier is required.", nameof(request));
        }

        string editorialBriefJson = JsonSerializer.Serialize(

            new
            {
                title = request.Title.Trim(),
                description = request.Description,
                targetAudience = request.TargetAudience,
                objective = request.Objective,
                tone= request.Tone,
                language = request.Language,
                plannedPublishDate = request.PlannedPublishDate
            },JsonOptions
            );

        ChatMessage[] messages = [
            new(ChatRole.System, EpisodePlannerPrompt.Instructions),
            new(ChatRole.User,
            $$"""
                Create one typed episode plan from the following persited editorial brief.
                Prompt versions : {{EpisodePlannerPrompt.Version}}
                <editorial-brief>
                    {{editorialBriefJson}}
                </editorial-brief>
            """)
        ];

        ChatOptions options = new()
        {
            MaxOutputTokens = 3_500
        };

        ChatResponse<EpisodePlan> response =await  chatClient.GetResponseAsync<EpisodePlan>(
                messages,
                JsonOptions,
                options,
                useJsonSchemaResponseFormat: true,
                cancellationToken: cancellationToken
            );

        if (response.TryGetResult(out EpisodePlan? plan) || plan is null)
        {
            logger.LogWarning("Microsoft Foundry returned an unusable strcutured episode" +
                "plan for episode {EpisodeId}. ResponseId: {ResponseId}; " +
                "FinishReason: {FinishReason}", request.EpisodeId, response.ResponseId, response.FinishReason);

            throw new InvalidOperationException("Microsoft foundry did not return a usable typed episode plan.");
        }

        DateTimeOffset generatedAtUtc = DateTimeOffset.UtcNow;
        return new EpisodePlanningResult(
            Plan: plan,
           PromptVersion: EpisodePlannerPrompt.Version,
           GeneratedAtUtc: generatedAtUtc
        );

       
    }
}
