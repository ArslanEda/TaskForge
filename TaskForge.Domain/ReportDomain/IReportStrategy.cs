using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.ReportDomain
{
    public interface IReportStrategy
    {
        string Format { get; }
        byte[] Generate(IEnumerable<ReportTaskItem> items);
    }
}
