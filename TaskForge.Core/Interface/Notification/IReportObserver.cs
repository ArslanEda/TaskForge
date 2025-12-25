using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Core.Interface.Notification
{
    public interface IReportObserver
    {
        void ReportGenerated(string format, string filePath);
    }
}
