using Microsoft.AspNetCore.SignalR;
using Service;
using SignalRSwaggerGen.Attributes;

namespace Controller.Hubs;

[SignalRHub]
public class ChatbotHub : Hub<IChatbotClient>
{
    private ChatbotService _chatbotService = new();
    
    public async Task SendMessage(string message) => 
        await Clients.All.ReceiveMessage(_chatbotService.GetByMessage(message));
}