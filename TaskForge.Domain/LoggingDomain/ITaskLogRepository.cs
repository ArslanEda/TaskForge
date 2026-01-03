using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.LoggingDomain
{
    public interface ITaskLogRepository
    {
        void AddLog(Log log);
    }
}
