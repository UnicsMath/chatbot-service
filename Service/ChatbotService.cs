using Repository;
using ViewModel;

namespace Service;

public class ChatbotService
{
    private IChatbot _chatBot = new RoboMaticAI();

    public MessagePayloadViewModel GetFromMessage(string message) => 
        MessagePayloadMapper.ToViewModel(_chatBot.GetResponse(message).Result);
}