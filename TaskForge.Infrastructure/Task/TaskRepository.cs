using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Task = TaskForge.Domain.TaskDomain.Task;
using TaskForge.Domain.TaskDomain;

namespace TaskForge.Infrastructure.TaskFile
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskStorage _storage;
        private readonly List<Task> _tasks;

        public TaskRepository(TaskStorage storage)
        {
            _storage = storage;
            _tasks = _storage.Load();
        }

        public List<Task> ListTask()
        {
            return _tasks;
        }

        public Task? GetByTaskId(int id)
        {
            return _tasks.FirstOrDefault(t => t.Id == id);
        }

        public void AddTask(Task task)
        {
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

        public void UpdateTask(Task task)
        {
            var update = GetByTaskId(task.Id);
            if (update != null)
            {
                _storage.Save(_tasks);
            }
        }
    }
}
