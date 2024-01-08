using Microsoft.AspNetCore.SignalR.Client;
using ViewModel;

HubConnection hubConnection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5118/ChatbotHub")
    .Build();

await hubConnection.StartAsync();

List<MessagePayloadViewModel> messages = [];

hubConnection.On<MessagePayloadViewModel>("ReceiveMessage", message =>
{
    messages.Add(message);
    messages.ForEach(Console.WriteLine);
});

Console.WriteLine("Enter your name:");
string? senderId = await Console.In.ReadLineAsync();

Console.Clear();

while (true)
{
    Console.WriteLine("Enter message:");
    string? message = await Console.In.ReadLineAsync();
    messages.Add(new(senderId, message));

    if (message == "exit") break;
    
    Console.Clear();

    try
    {
        await hubConnection.InvokeAsync("SendMessage", message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}