using Microsoft.AspNetCore.SignalR;

namespace Pratical.SignalRWebPack.Hubs;
public class AgentChatHub : Hub
{
    public async Task NewMessage(long username, string message)
        => await Clients.All.SendAsync("messageReceived", username, message);


    public override async Task OnConnectedAsync()
        => await Clients.Others.SendAsync("ReceiveNotification", $"{DateTime.Now.ToString("M/d/yyyy")} join chat");


    public override async Task OnDisconnectedAsync(Exception exception)
        => await Clients.Others.SendAsync("ReceiveNotification", $"{DateTime.Now.ToString("M/d/yyyy")} left chat");

}


