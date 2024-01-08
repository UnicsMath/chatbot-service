using Microsoft.AspNetCore.SignalR;
using Service;

namespace Controller.Hubs;

public class ChatBotHub : Hub<IChatBotClient>
{
    private ChatbotService _chatbotService = new();
    
    public async Task SendMessage(string message) => 
        await Clients.All.ReceiveMessage(_chatbotService.GetFromMessage(message));
}