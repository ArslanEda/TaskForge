using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.TaskDomain.Memento
{
    public class TaskMemento(Task? before, Task? after)
    {
        public Task? Before { get; } = before?.Clone();
        public Task? After { get; } = after?.Clone();
    }
}
