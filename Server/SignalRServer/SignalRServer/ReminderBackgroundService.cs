
namespace SignalRServer
{
    public class ReminderBackgroundService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public ReminderBackgroundService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(3000, stoppingToken);
                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var reminderExecutor = scope.ServiceProvider.GetService<IReminderExecutor>();

                        if (reminderExecutor != null)
                        {
                            await reminderExecutor.Run(new Notification { ThreadId = "thread-123", RunId = "run-456", Status = "completed" });
                        }
                    }
                }
                catch (Exception e)
                {
                    // TODO logging

                    var msg = e.Message;
                }
            }
        }
    }
}
