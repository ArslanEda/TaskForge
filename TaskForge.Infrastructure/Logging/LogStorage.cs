using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskForge.Domain.LoggingDomain;
using TaskForge.Infrastructure.FileSystem;

namespace TaskForge.Infrastructure.Logging
{
    public class LogStorage(FilePathProvider pathProvider)
    {
        private readonly string _logPath = Path.Combine(pathProvider.GetLogsFolder(), "logs.json");
        public List<Log> Load()
        {
            if (!File.Exists(_logPath))
            {
                return [];
            }
            return JsonSerializer.Deserialize<List<Log>>(File.ReadAllText(_logPath), JsonOption.Options) ?? [];
        }

        public void Save(Log log)
        {
            var logs = Load();
            logs.Add(log);
            File.WriteAllText(_logPath, JsonSerializer.Serialize(logs, JsonOption.Options));
        }
    }
}
