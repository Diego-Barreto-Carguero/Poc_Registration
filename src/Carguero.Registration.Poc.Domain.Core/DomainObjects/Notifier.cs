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

        public dynamic GetNotifications()
        {
            return new { errors = _notification.Select(s => s.Message).ToList() };
        }

        public dynamic GetNotifications(Exception exception)
        {
            NotifyHandle(exception.Message);

            return new { errors = _notification.Select(s => s.Message).ToList() };
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
