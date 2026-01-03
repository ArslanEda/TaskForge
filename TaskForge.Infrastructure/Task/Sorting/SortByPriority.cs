using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Domain.TaskDomain.Sorting;
using Task = TaskForge.Domain.TaskDomain.Task;

namespace TaskForge.Domain.Tasks.Sorting
{
    public class SortByPriority : ITaskSortByStrategy
    {
        public string Sorting => "priority";

        private static readonly Dictionary<string, int> Priority = new()
        {
            {"low",1 },
            {"medium",2 },
            {"high",3 }
        };

        public List<Task> Sort(List<Task> tasks)
        {
            return tasks.OrderByDescending(t => Priority[t.Priority.ToLower()]).ToList();
        }
    }
}
