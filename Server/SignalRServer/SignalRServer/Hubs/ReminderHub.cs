using Microsoft.AspNetCore.SignalR;

namespace SignalRServer.Hubs
{
    public class ReminderHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
