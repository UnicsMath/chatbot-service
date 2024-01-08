using SignalRSwaggerGen.Attributes;
using ViewModel;

namespace Controller.Hubs;

[SignalRHub]
public interface IChatbotClient
{
    Task ReceiveMessage(MessagePayloadViewModel messagePayloadViewModel);
}