using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using TaskForge.Core.Interface.History;
using TaskForge.Core.Interface.Infrastructure;
using TaskForge.Core.ValueObject;
using TaskForge.Infrastructure.Serialization;

namespace TaskForge.Infrastructure.Storage.History
{
    public class FileTaskHistoryStorage(IPathProvider pathProvider) : IHistoryStorage
    {
        private readonly string _undoPath = Path.Combine(pathProvider.GetHistoryFolder(), "undo.json");

        private readonly string _redoPath = Path.Combine(pathProvider.GetHistoryFolder(), "redo.json");

        public Stack<TaskSnapshot> LoadUndo()
        {
            if (!File.Exists(_undoPath))
            {
                return [];
            }

            var json = File.ReadAllText(_undoPath);
            return JsonSerializer.Deserialize<Stack<TaskSnapshot>>(json, JsonOption.Options) ?? [];
        }

        public Stack<TaskSnapshot> LoadRedo()
        {
            if (!File.Exists(_redoPath))
            {
                return [];
            }

            var json = File.ReadAllText(_redoPath);
            return JsonSerializer.Deserialize<Stack<TaskSnapshot>>(json, JsonOption.Options) ?? [];
        }

        public void SaveUndo(Stack<TaskSnapshot> undo)
        {
            var json = JsonSerializer.Serialize(undo, JsonOption.Options);
            File.WriteAllText(_undoPath, json);
        }

        public void SaveRedo(Stack<TaskSnapshot> redo)
        {
            var json = JsonSerializer.Serialize(redo, JsonOption.Options);
            File.WriteAllText(_redoPath, json);
        }
    }
}