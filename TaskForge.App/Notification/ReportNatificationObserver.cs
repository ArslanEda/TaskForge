using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Interface.Notification;

namespace TaskForge.App.Notification
{
    public class ReportNotificationObserver : IReportObserver
    {
        public void ReportGenerated(string format, string filePath)
        {
            Console.WriteLine($"[REPORT OBSERVER] report created successfully. {format.ToUpper()} - Path: {filePath}");
        }
    }
}
