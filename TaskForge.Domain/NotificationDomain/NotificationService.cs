using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.NotificationDomain
{
    public class NotificationService(IEnumerable<INotificationObserver> observers)
    {
        private readonly IEnumerable<INotificationObserver> _observers = observers;

        public void Notify(string type, string message)
        {
            foreach (var observer in _observers)
            {
                observer.Notify(type, message);
            }
        }
    }
}