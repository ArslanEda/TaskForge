using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskForge.Core.Entity;

namespace TaskForge.Core.Factory
{
    public class TaskFactory
    {
        public TaskBase Create(string type, string title, string priority)
        {
            return new TaskBase
            {
                Type = type,
                Title = title,
                Priority = priority,
                IsCompleted = false,
            };
        }
    }
}
