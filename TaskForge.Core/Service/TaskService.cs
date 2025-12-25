using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskFactory = TaskForge.Core.Factory.TaskFactory;
using TaskForge.Core.Interface.Repository;
using TaskForge.Core.Interface.Service;

namespace TaskForge.Core.Service
{
    public class TaskService(ITaskRepository repository, TaskFactory factory, TaskSnapshotService history) : ITaskService
    {
        private readonly ITaskRepository _repository = repository;
        private readonly TaskFactory _factory = factory;
        private readonly TaskSnapshotService _history = history;

        private TaskBase GetTaskOrThrow(int id)
        {
            return _repository.GetByTaskId(id) ?? throw new Exception($"Task with ID {id} not found.");
        }

        public List<TaskBase> ListTask()
        {
            return _repository.ListTask();
        }

        public TaskBase AddTask(string type, string title, string priority)
        {
            var task = _factory.Create(type, title, priority);
            _repository.AddTask(task);
            _history.Save(null, task.Clone());
            return task;
        }

        public TaskBase DeleteTask(int id)
        {
            var task = GetTaskOrThrow(id);
            _repository.DeleteTask(id);
            _history.Save(task.Clone(), null);
            return task;
        }

        public TaskBase UpdateTask(int id, string type, string title, string priority, bool completed)
        {
            var task = GetTaskOrThrow(id);
            var before = task.Clone();
            task.Update(type, title, priority, completed);
            _repository.UpdateTask(task);
            _history.Save(before, task.Clone());
            return task;
        }

        public TaskBase? Undo()
        {
            var step = _history.Undo();
            if (step == null)
            {
                return null;
            }

            if (step.Before == null && step.After != null)
            {
                _repository.DeleteTask(step.After.Id);
                return step.After;
            }

            if (step.Before != null && step.After == null)
            {
                _repository.AddTask(step.Before.Clone());
                return step.Before;
            }

            if (step.Before != null && step.After != null)
            {
                _repository.UpdateTask(step.Before.Clone());
                return step.Before;
            }

            return null;
        }
        
        public TaskBase? Redo()
        {
            var step = _history.Redo();
            if (step == null) return null;

            if (step.Before == null && step.After != null)
            {
                _repository.AddTask(step.After.Clone());
                return step.After;
            }

            if (step.Before != null && step.After == null)
            {
                _repository.DeleteTask(step.Before.Id);
                return step.Before;
            }

            if (step.Before != null && step.After != null)
            {
                _repository.UpdateTask(step.After.Clone());
                return step.After;
            }

            return null;
        }
    }
}
