using IcmChatApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;
using Microsoft.Extensions.VectorData;
using System.ComponentModel;

namespace IcmChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatClient _chatClient;
    private readonly VectorStoreCollection<string, IcmChunk> _icmCollection;

    private readonly ChatOptions _chatOptions= new();
    public ChatController(IChatClient chatClient, VectorStoreCollection<string, IcmChunk> icmCollection)
    {
        _chatClient = chatClient; 
        _icmCollection = icmCollection;
        _chatOptions.Tools =[
                AIFunctionFactory.Create(SearchIcmAsync)
            ];
    }

    [HttpPost]
    public async Task<ActionResult<Models.ChatResponse>> SendQuery([FromBody] ChatRequest query)  //ActionResult added for Azure
    {
        try
        {
            List<ChatMessage> messages = new List<ChatMessage>()
            {
                new ChatMessage(ChatRole.System, SystemPrompt),
                new ChatMessage(ChatRole.User, query.Query)
            };

            var response = await _chatClient.GetResponseAsync(messages, _chatOptions);

            return Ok(new Models.ChatResponse
            {
                Message = response.Text,
                Status = "Success"
            });
        }
        catch (OperationCanceledException)
        {

            return StatusCode(StatusCodes.Status499ClientClosedRequest);
        }
        catch (Exception ex)
        {
            return Problem(ex.Message);
        }
    }


    [Description("Search for information using a phrase or keyword. Relise on ICMs which already being loaded.")]
    private async Task<IEnumerable<string>> SearchIcmAsync([Description("The Phrase to search for.")]string searchPhrase)
    {
        var nearest = _icmCollection.SearchAsync(searchPhrase, 5);

        return await nearest.Select(result => result.Record.Content).ToListAsync();
    }

    private const string SystemPrompt = """
                                            You are an ICM Buddy assistant that answers questions ONLY using information retrieved from ICM incidents.

                                            Rules:
                                            - You MUST call the SearchIcmAsync tool before answering any question.
                                            - Use SearchIcmAsync with relevant keywords extracted from the user's question.
                                            - Answer ONLY using the information returned by SearchIcmAsync.
                                            - Do NOT use external knowledge.
                                            - Do NOT guess or speculate.
                                            - If the retrieved information is empty or not sufficient, respond with:
                                              "Not enough data in ICM history."

                                            Response format:
                                            - Use simple markdown only.
                                            - Structure your response as follows:

                                            Diagnosis:
                                            - Brief explanation based on retrieved incidents.

                                            Recommended Actions:
                                            - Concrete actions taken in past incidents.

                                            Related Incidents:
                                            - List incident IDs and a short reason for relevance.



                                                    
                                            """;

}
