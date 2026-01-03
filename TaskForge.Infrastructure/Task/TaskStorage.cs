using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using TaskForge.Infrastructure.FileSystem;
using Task = TaskForge.Domain.TaskDomain.Task;

namespace TaskForge.Infrastructure.TaskFile
{
    public class TaskStorage(FilePathProvider pathProvider) 
    {
        private readonly string _filePath = Path.Combine(pathProvider.GetDataFolder(), "tasks.json"); 

        public List<Task> Load()
        {
            if (!File.Exists(_filePath))
            {
                return [];
            }

            string json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Task>>(json, JsonOption.Options) ?? [];
        }

        public void Save(List<Task> data)
        {
            string json = JsonSerializer.Serialize(data, JsonOption.Options);
            File.WriteAllText(_filePath, json);
        }
    }
}
