using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.NotificationDomain
{
    public interface INotificationObserver
    {
        void Notify(string type, string message);
    }
}


