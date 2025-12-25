using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Sorting;

namespace TaskForge.Core.Sorting
{
    public class DateTaskSorter : ITaskSorting
    {
        public string Sorting => "date";
        public List<TaskBase> Sort(List<TaskBase> tasks)
        {
            return tasks.OrderByDescending(t => t.CreatedAt).ToList();
        }
    }
}
