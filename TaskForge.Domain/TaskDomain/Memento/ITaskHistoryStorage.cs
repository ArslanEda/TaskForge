using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.TaskDomain.Memento
{
    public interface ITaskHistoryStorage
    {
        Stack<TaskMemento> LoadUndo();
        Stack<TaskMemento> LoadRedo();
        void SaveUndo(Stack<TaskMemento> undo);
        void SaveRedo(Stack<TaskMemento> redo);
    }
}
