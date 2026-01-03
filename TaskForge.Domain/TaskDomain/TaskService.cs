using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.TaskDomain
{
    public class TaskService(ITaskRepository repository, TaskFactory factory)
    {
        private readonly ITaskRepository _repository = repository;
        private readonly TaskFactory _factory = factory;

        private Task GetTaskOrThrow(int id)
        {
            return _repository.GetByTaskId(id) ?? throw new Exception($"Task with ID {id} not found.");
        }

        public List<Task> ListTask()
        {
            return _repository.ListTask();
        }

        public Task AddTask(string type, string title, string priority)
        {
            var task = _factory.Create(type, title, priority);
            task.Id = GenerateId();
            _repository.AddTask(task);
            return task;
        }

        private int GenerateId()
        {
            var tasks = _repository.ListTask();
            return tasks.Count == 0 ? 1 : tasks.Max(t => t.Id) + 1;
        }

        public Task DeleteTask(int id)
        {
            var task = GetTaskOrThrow(id);
            _repository.DeleteTask(id);
            return task;
        }

        public Task UpdateTask(int id, string type, string title, string priority, bool completed)
        {
            var task = GetTaskOrThrow(id);
            task.Update(type, title, priority, completed);
            _repository.UpdateTask(task);
            return task;
        }
    }
}
