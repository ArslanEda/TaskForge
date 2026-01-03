using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace TaskForge.Application.RequestModel
{
    public class UpdateTaskRequest
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public bool IsCompleted { get; set; }
    }
}
