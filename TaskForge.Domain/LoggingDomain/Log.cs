using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace TaskForge.Domain.LoggingDomain
{
    public class Log
    {
        public string Time { get; set; } = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
        public string Action { get; set; }
        public string Message { get; set; }
        public string Status { get; set; }
    }
}
