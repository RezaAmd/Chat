namespace WebUi.Hubs;

public class ChatHub : Hub
{
    [Authorize]
    public async Task SendBroadcastMessage(string user, string message)
    {
        await Clients.All.SendAsync("RecieveMessage", user, message);
    }

    [Authorize]
    public async Task SendMessage(string user, string receiverConnectionId, string message)
    {
        await Clients.Client(receiverConnectionId).SendAsync("RecieveMessage", user, message);
    }

    public string UserOnConnected() => Context.ConnectionId;
}