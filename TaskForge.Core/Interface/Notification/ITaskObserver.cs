using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;

namespace TaskForge.Core.Interface.Notification
{
    public interface ITaskObserver
    {
        void TaskAdded(TaskBase task);
        void TaskDeleted(TaskBase task);
        void TaskUpdated(TaskBase task);
        void TaskUndo(TaskBase task);
        void TaskRedo(TaskBase task);
    }
}
