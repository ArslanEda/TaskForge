using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task = TaskForge.Domain.TaskDomain.Task;

namespace TaskForge.Domain.TaskDomain.Sorting
{
    public interface ITaskSortByStrategy
    {
        string Sorting { get; }
        List<Task> Sort(List<Task> tasks);
    }
}
