using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;

namespace TaskForge.Core.ValueObject
{
    public class TaskSnapshot(TaskBase? before, TaskBase? after)
    {
        public TaskBase? Before { get; } = before?.Clone();
        public TaskBase? After { get; } = after?.Clone();
    }
}

