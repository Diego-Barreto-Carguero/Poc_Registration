using Carguero.Registration.Poc.Domain.Core.Contracts;
using Carguero.Registration.Poc.Domain.Core.DataTransferObject;

namespace Carguero.Registration.Poc.Domain.Core.DomainObjects
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notification;

        public Notifier()
        {
            _notification = new List<Notification>();
        }

        public List<Notification> GetNotifications()
        {
            return _notification;
        }

        public void NotifyHandle(string notification)
        {
            _notification.Add(new Notification(notification));
        }

        public bool HasNotification()
        {
            return _notification.Any();
        }
    }
}
