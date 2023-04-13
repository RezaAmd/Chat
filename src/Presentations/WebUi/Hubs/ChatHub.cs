namespace WebUi.Hubs;

public class ChatHub : Hub
{
    public async Task SendBroadcastMessage(string user, string message)
    {
        await Clients.All.SendAsync("RecieveMessage", user, message);
    }

    public async Task SendMessage(string user, string receiverConnectionId, string message)
    {
        await Clients.Client(receiverConnectionId).SendAsync("RecieveMessage", user, message);
    }

    public string UserOnConnected() => Context.ConnectionId;
}