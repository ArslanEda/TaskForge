using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace TaskForge.Domain.TaskDomain
{
    public class Task
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
        public string CreatedAt { get; set; } = DateTime.Now.ToString("dd-MM-yyyy HH:mm");

        public void Update (string type, string title, string priority, bool completed)
        {
            Type = type;
            Title = title;
            Priority = priority;
            IsCompleted = completed;
        }

        public Task Clone()
        {
            return (Task)MemberwiseClone();
        }
    }
}
