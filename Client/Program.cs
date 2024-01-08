using Microsoft.AspNetCore.SignalR.Client;

HubConnection connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5118/ChatBotHub")
    .Build();

await connection.StartAsync();

List<string> messages = [];

connection.On<string>("ReceiveMessage", (message) =>
{
    messages.Add(message);
    messages.ForEach(Console.WriteLine);
});

Console.WriteLine("Enter your name:");
string? name = await Console.In.ReadLineAsync();

Console.Clear();

while (true)
{
    Console.WriteLine("Enter message:");
    string? message = await Console.In.ReadLineAsync();
    messages.Add($"{name}: {message}");

    if (message == "exit") break;
    
    Console.Clear();

    try
    {
        await connection.InvokeAsync("SendMessage", 
            name, message);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}