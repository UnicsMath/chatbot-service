using Model;

namespace Repository;

public interface IChatbot
{
    Task<MessagePayloadModel> GetByMessage(string message);
}