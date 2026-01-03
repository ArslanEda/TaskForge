using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.ReportDomain
{
    public class ReportService(IReportStorage storage, ReportFactory factory)
    {
        public readonly IReportStorage _storage = storage;
        public readonly ReportFactory _factory = factory;

        public Report GenerateReport(IEnumerable<ReportTaskItem> items, IReportStrategy strategy)
        {
            var report = _factory.Create(strategy.Format);
            var data = strategy.Generate(items);
            _storage.Save(report, data);

            return report;
        }

        public IReadOnlyList<string> ListReports()
        {
            return _storage.ListReports();
        }

        public string GetReportPath(string fileName)
        {
            return _storage.GetReportPath(fileName);
        }
    }
}
