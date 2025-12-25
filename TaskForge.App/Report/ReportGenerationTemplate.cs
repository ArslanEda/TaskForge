using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Infrastructure;
using TaskForge.Core.Interface.Report;

namespace TaskForge.App.Report
{
    public abstract class ReportGenerationTemplate(IReportStrategy strategy, IReportStorage storage, IPathProvider pathProvider)
    {
        protected readonly IReportStrategy _strategy = strategy;
        protected readonly IReportStorage _storage = storage;
        protected readonly IPathProvider _pathProvider = pathProvider;

        public string Generate(List<TaskBase> tasks)
        {
            var bytes = _strategy.Select(tasks);
            var folder = _pathProvider.GetReportsFolder();
            var fileName = $"{DateTime.Now:dd.MM.yyyy_HH.mm}_{_strategy.Format}";
            var path = Path.Combine(folder, fileName);
            _storage.Save(path, bytes);
            return path;
        }
    }

    public class ReportGenerator(IReportStrategy strategy, IReportStorage storage, IPathProvider pathProvider) : ReportGenerationTemplate(strategy, storage, pathProvider)
    {
    }
}
