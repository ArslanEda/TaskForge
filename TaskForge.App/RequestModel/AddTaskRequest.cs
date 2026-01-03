using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace TaskForge.Application.RequestModel
{
    public class AddTaskRequest
    {
        public string Type { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
    }
}
