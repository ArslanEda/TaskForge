using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Logging;

namespace TaskForge.App.Decorater
{
    public class TaskLogService(ILogWriter writer)
    {
        private readonly ILogWriter _writer = writer;

        public void Log(string action, string message, string status = "Success")
        {
            _writer.AppendLog(DateTime.Now, $"Task | {action}", message, status);
        }
    }
}
    