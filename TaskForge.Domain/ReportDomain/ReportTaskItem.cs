using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace TaskForge.Domain.ReportDomain
{
    public record ReportTaskItem(int Id, string Type, string Title, string Priority, bool IsCompleted, string CreatedAt);
}
