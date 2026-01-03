using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.NotificationDomain
{
    public class ConsoleNotificationObserver : INotificationObserver
    {
        public void Notify(string type, string message)
        {
            Console.WriteLine($"[NOTIFICATION] {type} | {message}");
        }
    }
}
