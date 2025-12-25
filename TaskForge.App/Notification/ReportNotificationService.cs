using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Interface.Notification;

namespace TaskForge.App.Notification
{
    public class ReportNotificationService(IEnumerable<IReportObserver> observers)
    {
        private readonly IEnumerable<IReportObserver> _observers = observers;

        public void NotifyReportGenerated(string format, string filePath)
        {
            foreach (var obs in _observers)
            {
                obs.ReportGenerated(format, filePath);
            }
        }
    }
}