using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Report;
using TaskForge.App.RequestModel;
using TaskForge.App.Notification;
using TaskForge.Core.Service;
using TaskForge.App.Validation;

namespace TaskForge.App.Report
{
    public class ReportService(IEnumerable<IReportStrategy> builder, IReportStorage storage, ReportFactory reportFactory, ReportNotificationService notifier, IRequestValidaton validaton, TaskService taskService)
    {
        private readonly IEnumerable<IReportStrategy> _builder = builder;
        private readonly IReportStorage _storage = storage;
        private readonly ReportFactory _reportFactory = reportFactory;
        private readonly IRequestValidaton _validation = validaton;
        private readonly ReportNotificationService _notifier = notifier;
        private readonly TaskService _taskService = taskService;

        public void GenerateReport(GenerateReportRequest request)
        {
            _validation.Validate(request);

            var tasks = _taskService.ListTask();
            var builder = _builder.First(b => b.Format.Equals(request.Format, StringComparison.OrdinalIgnoreCase));
            var generator = _reportFactory.Create(builder);
            var path = generator.Generate(tasks);

            _notifier.NotifyReportGenerated(request.Format, path);
        }

        public IReadOnlyList<string> GetReportFiles()
        {
            return _storage.GetReportFiles();
        }

        public void OpenReport(string fileName)
        {
            _storage.OpenReport(fileName);
        }

    }
}

