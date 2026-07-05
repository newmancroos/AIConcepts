using IcmChatApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;

namespace IcmChatApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatClient _chatClient;
    public ChatController(IChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    [HttpPost]
    public async Task<Models.ChatResponse> SendQuery([FromBody] ChatRequest query)
    {
        List<ChatMessage> messages = new List<ChatMessage>()
        {
            new ChatMessage(ChatRole.System, "You are a general Chat system"),
            new ChatMessage(ChatRole.User, query.Query)
        };

        var response =await  _chatClient.GetResponseAsync(messages, new ChatOptions());

        return new Models.ChatResponse
        {
            Message = response.Text,
            Status = "Success"
        };
    }

}
