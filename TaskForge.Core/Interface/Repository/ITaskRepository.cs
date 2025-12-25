using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskForge.Core.Entity;

namespace TaskForge.Core.Interface.Repository
{
    public interface ITaskRepository
    {
        List<TaskBase> ListTask();
        TaskBase? GetByTaskId(int id);
        void AddTask(TaskBase task);
        void DeleteTask(int id);
        void UpdateTask(TaskBase task);
    }
}
