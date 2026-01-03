using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TaskForge.Domain.TaskDomain.Memento
{
    public class TaskCaretakerService(ITaskHistoryStorage storage)
    {
        private readonly ITaskHistoryStorage _storage = storage;
        private readonly Stack<TaskMemento> _undo = storage.LoadUndo();
        private readonly Stack<TaskMemento> _redo = storage.LoadRedo();

        public void Save(Task? before, Task? after)
        {
            _undo.Push(new TaskMemento(before, after));
            _redo.Clear();
            SaveAll();
        }

        public TaskMemento? Undo()
        {
            if (_undo.Count == 0)
            {
                return null;
            }
            var removed = _undo.Pop();
            _redo.Push(removed);
            SaveAll();

            return removed;
        }

        public TaskMemento? Redo()
        {
            if (_redo.Count == 0)
            {
                return null;
            }
            var memory = _redo.Pop();
            _undo.Push(memory);
            SaveAll();

            return memory;
        }

        private void SaveAll()
        {
            _storage.SaveUndo(_undo);
            _storage.SaveRedo(_redo);
        }

        public List<string> GetHistory()
        {
            var list = new List<string>();

            foreach (var h in _undo)
            {
                if (h.Before == null && h.After != null)
                {
                    list.Add($"[ADD] | {h.After.Title}");
                }
                else if (h.Before != null && h.After == null)
                {
                    list.Add($"[DELETE] | {h.Before.Title}");
                }
                else
                {
                    list.Add($"[UPDATE] | {h.Before?.Title} - {h.After?.Title}");
                }
            }

            return list;
        }
    }
}
