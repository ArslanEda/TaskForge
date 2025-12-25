using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Infrastructure;
using TaskForge.Infrastructure.Serialization;

namespace TaskForge.Infrastructure.Storage.Task
{
    public class FileTaskStorage (IPathProvider pathProvider) 
    {
        private readonly string _path = Path.Combine(pathProvider.GetDataFolder(), "tasks.json");

        public List<TaskBase> Load()
        {
            if (!File.Exists(_path))
            {
                return [];
            }

            string json = File.ReadAllText(_path);
            return JsonSerializer.Deserialize<List<TaskBase>>(json, JsonOption.Options) ?? [];
        }

        public void Save(List<TaskBase> data)
        {
            string json = JsonSerializer.Serialize(data, JsonOption.Options);
            File.WriteAllText(_path, json);
        }
    }
}
