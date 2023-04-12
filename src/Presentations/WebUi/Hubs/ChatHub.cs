using Microsoft.AspNetCore.SignalR;

namespace WebUi.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessageAsync(string user, string message)
    {
        await Clients.All.SendAsync("RecieveMessage", user, message);
    }
}