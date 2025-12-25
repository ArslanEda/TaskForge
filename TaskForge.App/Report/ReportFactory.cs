using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Interface.Infrastructure;
using TaskForge.Core.Interface.Report;

namespace TaskForge.App.Report
{
    public class ReportFactory(IReportStorage storage, IPathProvider pathProvider)
    {
        private readonly IReportStorage _storage = storage;
        private readonly IPathProvider _pathProvider = pathProvider;

        public ReportGenerationTemplate Create(IReportStrategy strategy)
        {
            return new ReportGenerator(strategy, _storage, _pathProvider);
        }
    }
}
