using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.LoggingDomain
{
    public class LogService(LogFactory factory, ITaskLogRepository repository)
    {
        private readonly LogFactory _factory = factory;
        private readonly ITaskLogRepository _repository = repository;

        public Log AddLog(string action, string message, string status)
        {
            var log = _factory.Create(action, message, status);
            _repository.AddLog(log);
            return log;
        }
    }
}
