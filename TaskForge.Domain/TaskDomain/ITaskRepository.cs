using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.TaskDomain
{
    public interface ITaskRepository
    {
        List<Task> ListTask();
        Task? GetByTaskId(int id);
        void AddTask(Task task);
        void DeleteTask(int id);
        void UpdateTask(Task task);
    }
}
