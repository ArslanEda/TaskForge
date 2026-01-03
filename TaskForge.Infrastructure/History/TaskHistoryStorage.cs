using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Infrastructure.FileSystem;
using System.Text.Json;
using TaskForge.Domain.TaskDomain.Memento;

namespace TaskForge.Infrastructure.HistoryFile
{
    public class TaskHistoryStorage(FilePathProvider pathProvider) : ITaskHistoryStorage
    {
        private readonly string _undoPath = Path.Combine(pathProvider.GetHistoryFolder(), "undo.json");
        private readonly string _redoPath = Path.Combine(pathProvider.GetHistoryFolder(), "redo.json");

        public Stack<TaskMemento> LoadUndo()
        {
            return Load(_undoPath);
        }

        public Stack<TaskMemento> LoadRedo()
        {
            return Load(_redoPath);
        }

        public void SaveUndo(Stack<TaskMemento> undo)
        {
            Save(_undoPath, undo);
        }

        public void SaveRedo(Stack<TaskMemento> redo)
        {
            Save(_redoPath, redo);
        }

        public static Stack<TaskMemento> Load(string path)
        {
            if (!File.Exists(path))
            {
                return new Stack<TaskMemento>();
            }

            var json = File.ReadAllText(path);

            return JsonSerializer.Deserialize<Stack<TaskMemento>>(json, JsonOption.Options) ?? new Stack<TaskMemento>();
        }

        public static void Save(string path, Stack<TaskMemento> data)
        {
            var json = JsonSerializer.Serialize(data, JsonOption.Options);
            File.WriteAllText(path, json);
        }
    }
}