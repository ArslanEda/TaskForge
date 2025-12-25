using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Core.Interface.Logging
{
    public interface ILogWriter
    {
        void AppendLog(DateTime timestamp, string action, string message, string status);
    }
}
