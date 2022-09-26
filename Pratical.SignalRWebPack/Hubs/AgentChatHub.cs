using Microsoft.AspNetCore.SignalR;

namespace Pratical.SignalRWebPack.Hubs;
public class AgentChatHub : Hub
{
    public async Task SendAll(long username, string message)
        => await Clients.All.SendAsync("messageReceived", username, message);

    public async Task SendToConnection(string data, string connectionId)
    => await Clients.Client(connectionId).SendAsync("broadcasttoclient", data);

    public async Task SendToUser(string data, string userId)
    => await Clients.User(userId).SendAsync("broadcasttouser", data);
}


