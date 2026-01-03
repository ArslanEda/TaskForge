using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Domain.LoggingDomain;
using TaskForge.Infrastructure.Logging;


namespace TaskForge.Infrastructure.Logging
{
    public class LogRepository(LogStorage storage) : ITaskLogRepository
    {
        private readonly LogStorage _storage = storage;

        public void AddLog(Log log)
        {
            _storage.Save(log);
        }
    }
}


