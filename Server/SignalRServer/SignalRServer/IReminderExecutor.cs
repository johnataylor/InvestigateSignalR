namespace SignalRServer
{
    public interface IReminderExecutor
    {
        Task Run(Notification notification);
    }
}
