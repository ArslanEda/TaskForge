using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Interface.Service;
using TaskForge.Core.Entity;
using TaskForge.App.Decorater;
using TaskForge.App.Notification;

namespace TaskForge.App.Decorator
{
    public class TaskServiceDecorator(ITaskService inner, TaskLogService logger, TaskNotificationService notifier) : ITaskService
    {
        private readonly ITaskService _inner = inner;
        private readonly TaskLogService _logger = logger;
        private readonly TaskNotificationService _notification = notifier;

        public List<TaskBase> ListTask()
        {
            return _inner.ListTask();
        }

        public TaskBase AddTask(string type, string title, string priority)
        {
            try
            {
                var task = _inner.AddTask(type, title, priority);
                _logger.Log("AddTask", $"Added [{task.Id}] - {task.Title}");
                _notification.TaskAdded(task);
                return task;
            }
            catch (Exception ex)
            {
                _logger.Log("AddTask", ex.Message, "Failed");
                throw;
            }
        }

        public TaskBase DeleteTask(int id)
        {
            try
            {
                var task = _inner.DeleteTask(id);
                _logger.Log("DeleteTask", $"Deleted task [{id}]");
                _notification.TaskDeleted(task);
                return task;
            }
            catch (Exception ex)
            {
                _logger.Log("DeleteTask", ex.Message, "Failed");
                throw;
            }
        }

        public TaskBase UpdateTask(int id, string type, string title, string priority, bool completed)
        {
            try
            {
                var task = _inner.UpdateTask(id, type, title, priority, completed);
                _logger.Log("UpdateTask", $"Updated task [{id}]");
                _notification.TaskUpdated(task);
                return task;
            }
            catch (Exception ex)
            {
                _logger.Log("UpdateTask", ex.Message, "Failed");
                throw;
            }
        }

        public TaskBase? Undo()
        {
            try
            {
                var task = _inner.Undo();
                if (task != null)
                {
                    _logger.Log("Undo", $"Undo applied for [{task.Id}]");
                    _notification.TaskUndo(task);
                }

                return task;
            }
            catch (Exception ex)
            {
                _logger.Log("Undo", ex.Message, "Failed");
                throw;
            }
        }

        public TaskBase? Redo()
        {
            try
            {
                var task = _inner.Redo();
                if (task != null)
                {
                    _logger.Log("Redo", $"Redo applied for [{task.Id}]");
                    _notification.TaskRedo(task);
                }

                return task;
            }
            catch (Exception ex)
            {
                _logger.Log("Redo", ex.Message, "Failed");
                throw;
            }
        }
    }
}

