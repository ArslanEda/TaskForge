using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.ValueObject;

namespace TaskForge.Core.Interface.History
{
    public interface IHistoryStorage
    {
        Stack<TaskSnapshot> LoadUndo();
        Stack<TaskSnapshot> LoadRedo();
        void SaveUndo(Stack<TaskSnapshot> undo);
        void SaveRedo(Stack<TaskSnapshot> redo);
    }

}
