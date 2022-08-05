using Carguero.Registration.Poc.Domain.Core.DataTransferObject;

namespace Carguero.Registration.Poc.Domain.Core.Contracts
{
    public interface INotifier
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void NotifyHandle(string notification);
    }
}
