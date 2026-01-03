using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskForge.Domain.TaskDomain.Sorting;
using Task = TaskForge.Domain.TaskDomain.Task;

namespace TaskForge.Infrastructure.Tasks.Sorting
{
    public class SortByCreatedDate : ITaskSortByStrategy
    {
        public string Sorting => "date";
        public List<Task> Sort(List<Task> tasks)
        {
            return tasks.OrderByDescending(t => t.CreatedAt).ToList();
        }
    }
}
