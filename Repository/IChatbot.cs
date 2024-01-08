using Model;

namespace Repository;

public interface IChatbot
{
    Task<MessagePayloadModel> GetResponse(string message);
}