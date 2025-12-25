using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Repository;
using TaskForge.Infrastructure.Storage.Reports.Storage;
using TaskForge.Infrastructure.Storage.Task;

namespace TaskForge.Infrastructure.Repository
{

    public class TaskRepository : ITaskRepository
    {
        private readonly FileTaskStorage _storage;
        private readonly List<TaskBase> _tasks;

        public TaskRepository(FileTaskStorage storage)
        {
            _storage = storage;
            _tasks = _storage.Load(); 
        }

        public List<TaskBase> ListTask()
        {
            return _tasks;
        }

        public TaskBase? GetByTaskId(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(TaskBase task)
        {
            task.Id = _tasks.Count == 0 ? 1 : _tasks.Max(t => t.Id) + 1;
            _tasks.Add(task);
            _storage.Save(_tasks);
        }

        public void DeleteTask(int id)
        {
            var task = GetByTaskId(id);
            if (task == null) 
            {
                return;
            } 
            _tasks.Remove(task);
            _storage.Save(_tasks);
        }

        public void UpdateTask(TaskBase task)
        {
            var update = GetByTaskId(task.Id);
            if (update != null)
            {
                _storage.Save(_tasks);
            }
        }
    }
}