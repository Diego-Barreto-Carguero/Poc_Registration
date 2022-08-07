namespace Carguero.Registration.Poc.Domain.Core.Contracts
{
    public interface INotifier
    {
        bool HasNotification();

        dynamic GetNotifications();

        dynamic GetNotifications(Exception exception);

        void NotifyHandle(string notification);
    }
}
