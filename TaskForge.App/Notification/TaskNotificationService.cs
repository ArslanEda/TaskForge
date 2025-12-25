using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Notification;

namespace TaskForge.App.Notification
{
    public class TaskNotificationService(IEnumerable<ITaskObserver> observers)
    {
        private readonly IEnumerable<ITaskObserver> _observers = observers;

        public void TaskAdded(TaskBase task)
        {
            foreach (var obs in _observers)
            {
                obs.TaskAdded(task);
            }
        }

        public void TaskUpdated(TaskBase task)
        {
            foreach (var obs in _observers)
            {
                obs.TaskUpdated(task);
            }
        }

        public void TaskDeleted(TaskBase task)
        {
            foreach (var obs in _observers)
            {
                obs.TaskDeleted(task);
            }
        }

        public void TaskUndo(TaskBase task)
        {
            foreach (var obs in _observers)
            {
                obs.TaskUndo(task);
            }
        }

        public void TaskRedo(TaskBase task)
        {
            foreach (var obs in _observers)
            {
                obs.TaskRedo(task);
            }
        }
    }
}

