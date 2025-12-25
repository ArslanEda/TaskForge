using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
#nullable disable

namespace TaskForge.Infrastructure.Storage.Logging
{
    public class TaskLogEntry
    {
        public string Time { get; set; }
        public string Action { get; set; }
        public string Message { get; set; } 
        public string Status { get; set; }
    }
}

