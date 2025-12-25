using OfficeOpenXml.Packaging.Ionic.Zlib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Notification;

namespace TaskForge.App.Notification
{
    public class TaskNotificationObserver : ITaskObserver
    {
        public void TaskAdded(TaskBase task)
        {
            Console.WriteLine($"[TASK OBSERVER] Task is added - ID:{task.Id}");
        }

        public void TaskDeleted(TaskBase task)
        {
            Console.WriteLine($"[TASK OBSERVER] Task is deleted - ID:{task.Id}");
        }

        public void TaskUpdated(TaskBase task)
        {
            Console.WriteLine($"[TASK OBSERVER] Task is updated - ID:{task.Id}");
        }

        public void TaskUndo(TaskBase task)
        {
            Console.WriteLine($"[TASK OBSERVER] Undo - Task reverted - ID:{task.Id}");
        }

        public void TaskRedo(TaskBase task)
        {
            Console.WriteLine($"[TASK OBSERVER] Redo - Task restored - ID:{task.Id}");
        }

    }
}

