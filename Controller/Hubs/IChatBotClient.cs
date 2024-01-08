using ViewModel;

namespace Controller.Hubs;

public interface IChatBotClient
{
    Task ReceiveMessage(MessagePayloadViewModel messagePayloadViewModel);
}