using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.History;
using TaskForge.Core.ValueObject;

namespace TaskForge.Core.Service
{
    public class TaskSnapshotService(IHistoryStorage storage)
    {
        private readonly IHistoryStorage _storage = storage;
        private readonly Stack<TaskSnapshot> _undo = storage.LoadUndo();
        private readonly Stack<TaskSnapshot> _redo = storage.LoadRedo();

        public void Save(TaskBase? before, TaskBase? after)
        {
            _undo.Push(new TaskSnapshot(before, after));
            _redo.Clear();
            SaveAll();
        }

        public TaskSnapshot? Undo()
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

        public TaskSnapshot? Redo()
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

        public List<string> GetUndoHistory()
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
