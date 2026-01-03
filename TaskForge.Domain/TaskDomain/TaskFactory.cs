using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.TaskDomain
{
    public class TaskFactory
    {
        public Task Create(string type, string title, string priority)
        {
            return new Task
            {
                Type = type,
                Title = title,
                Priority = priority,
                IsCompleted = false,
            };
        }
    }
}
