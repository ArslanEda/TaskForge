using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.LoggingDomain
{
    public class LogFactory
    {
        public Log Create(string action, string message, string status)
        {
            return new Log
            {
                Action = action,
                Message = message,
                Status = status,
            };
        }
    }
}
