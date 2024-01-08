using Model;
using Newtonsoft.Json;

namespace Repository;

public class RoboMaticAI : IChatbot
{
    public async Task<MessagePayloadModel> GetByMessage(string message)
    {
        HttpClient client = new();
        HttpRequestMessage request = new()
        {
            Method = HttpMethod.Post,
            RequestUri = new("https://robomatic-ai.p.rapidapi.com/api"),
            Headers =
            {
                { "X-RapidAPI-Key", "" },
                { "X-RapidAPI-Host", "robomatic-ai.p.rapidapi.com" },
            },
            Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "in", message },
                { "op", "in" },
                { "cbot", "1" },
                { "SessionID", "RapidAPI1" },
                { "cbid", "1" },
                { "key", "" },
                { "ChatSource", "RapidAPI" },
                { "duration", "1" },
            }),
        };
        using HttpResponseMessage response = await client.SendAsync(request);
        response.EnsureSuccessStatusCode();
        string body = await response.Content.ReadAsStringAsync();

        ChatbotResponse chatbotResponse = JsonConvert.DeserializeObject<ChatbotResponse>(body);
        
        return new(chatbotResponse.Who, chatbotResponse.Out);
    }
}