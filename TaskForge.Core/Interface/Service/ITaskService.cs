using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;

namespace TaskForge.Core.Interface.Service
{
    public interface ITaskService
    {
        List<TaskBase> ListTask();
        TaskBase AddTask(string type, string title, string priority);
        TaskBase DeleteTask(int id);
        TaskBase UpdateTask(int id, string type, string title, string priority, bool completed);
        TaskBase? Undo();
        TaskBase? Redo();
    }
}
