using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskForge.Domain.ReportDomain;
using TaskForge.Infrastructure.FileSystem;

namespace TaskForge.Infrastructure.ReportStorage.Strategy
{
    public class JsonReportGenerator : IReportStrategy
    {
        public string Format => "json";

        public byte[] Generate(IEnumerable<ReportTaskItem> items)
        {
            return JsonSerializer.SerializeToUtf8Bytes(items, JsonOption.Options);
        }
    }
}
