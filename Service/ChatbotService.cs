using Repository;
using ViewModel;

namespace Service;

public class ChatbotService
{
    private IChatbot _chatBot = new RoboMaticAI();

    public MessagePayloadViewModel GetByMessage(string message) => 
        MessagePayloadMapper.ToViewModel(_chatBot.GetByMessage(message).Result);
}