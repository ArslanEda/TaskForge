using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using TaskForge.Core.Interface.Infrastructure;
using TaskForge.Core.Interface.Logging;
using TaskForge.Infrastructure.Serialization;

namespace TaskForge.Infrastructure.Storage.Logging
{
    public class FileTaskLogStorage(IPathProvider pathProvider) : ILogWriter
    {
        private readonly string _logFilePath = Path.Combine(pathProvider.GetLogsFolder(), "task_logs.json");

        public void AppendLog(DateTime timestamp, string action, string message, string status)
        {
            if (!File.Exists(_logFilePath))
            {
                File.WriteAllText(_logFilePath, "[]");
            }

            var json = File.ReadAllText(_logFilePath);
            var logs = JsonSerializer.Deserialize<List<TaskLogEntry>>(json) ?? [];

            logs.Add(new TaskLogEntry
            {
                Time = timestamp.ToString("G"),
                Action = action,
                Message = message,
                Status = status
            });

            File.WriteAllText(_logFilePath, JsonSerializer.Serialize(logs, JsonOption.Options));
        }
    }
}
