using Microsoft.AspNetCore.SignalR;
using SignalRServer.Hubs;

namespace SignalRServer
{
    public class ReminderExecutor : IReminderExecutor
    {
        private readonly IHubContext<ReminderHub> _hubContext;

        public ReminderExecutor(IHubContext<ReminderHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task Run(Notification notification)
        {
            await _hubContext.Clients.All.SendAsync("notification", notification);
        }
    }
}
