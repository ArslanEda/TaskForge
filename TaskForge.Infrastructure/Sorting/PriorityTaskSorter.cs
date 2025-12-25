using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Sorting;

namespace TaskForge.Core.Sorting
{
    public class PriorityTaskSorter : ITaskSorting
    {
        public string Sorting => "priority";

        private static readonly Dictionary<string, int> Priority = new()
        {
            {"low",1 },
            {"medium",2 },
            {"high",3 }
        };

        public List<TaskBase> Sort(List<TaskBase> tasks)
        {
            return tasks.OrderByDescending(t => Priority[t.Priority.ToLower()]).ToList();
        }
    }
}