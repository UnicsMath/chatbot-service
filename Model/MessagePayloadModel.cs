namespace Model;

public class MessagePayloadModel
{
    public string SenderId { get; set; }
    public string Message { get; set; }

    public MessagePayloadModel(string senderId, string message)
    {
        SenderId = senderId;
        Message = message;
    }
}