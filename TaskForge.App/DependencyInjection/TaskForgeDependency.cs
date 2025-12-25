using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaskForge.App.Facade;
using TaskForge.App.Decorator;
using TaskForge.App.Notification;
using TaskForge.App.Report;
using TaskFactory = TaskForge.Core.Factory.TaskFactory;
using TaskForge.Core.Interface.History;
using TaskForge.Core.Interface.Logging;
using TaskForge.Core.Interface.Report;
using TaskForge.Core.Interface.Service;
using TaskForge.Core.Service;
using TaskForge.Core.Sorting;
using TaskForge.Infrastructure.Repository;
using TaskForge.Infrastructure.Storage.History;
using TaskForge.Infrastructure.Storage.Logging;
using TaskForge.Infrastructure.Storage.Reports.Storage;
using TaskForge.Infrastructure.Storage.Task;
using TaskForge.Infrastructure.Storage.Reports.Strategy;
using TaskForge.Core.Interface.Notification;
using TaskForge.Core.Interface.Repository;
using TaskForge.Core.Interface.Infrastructure;
using TaskForge.Infrastructure.Storage;
using TaskForge.Core.Interface.Sorting;
using TaskForge.App.Decorater;
using TaskForge.App.Sorting;
using TaskForge.App.Validation;
using TaskForge.App.RequestModel;

namespace TaskForge.App.DependencyInjection
{
    public static class TaskForgeDependency
    {
        public static void AddServices(IServiceCollection services)
        {
            services.AddSingleton<TaskFactory>();
            services.AddSingleton<TaskSnapshotService>();
            services.AddSingleton<TaskNotificationService>();

            services.AddSingleton<ITaskSorting, PriorityTaskSorter>();
            services.AddSingleton<ITaskSorting, DateTaskSorter>();

            services.AddSingleton<TaskSortingSelector>();

            services.AddSingleton<FileTaskStorage>();
            services.AddSingleton<ITaskRepository, TaskRepository>();

            services.AddSingleton<IPathProvider, FilePathProvider>();

            services.AddSingleton<IHistoryStorage, FileTaskHistoryStorage>();
            services.AddSingleton<ILogWriter, FileTaskLogStorage>();

            services.AddSingleton<IReportStrategy, JsonReport>();
            services.AddSingleton<IReportStrategy, PdfReport>();
            services.AddSingleton<IReportStrategy, XlsxReport>();

            services.AddSingleton<IReportStorage, FileReportStorage>();

            services.AddSingleton<ITaskObserver, TaskNotificationObserver>();
            services.AddSingleton<IReportObserver, ReportNotificationObserver>();
            services.AddSingleton<ReportNotificationService>();

            services.AddSingleton<ReportFactory>();
            services.AddSingleton<ReportService>();

            services.AddSingleton<IRequestValidaton, RequestValidaton>();
            services.AddSingleton<IValidator<AddTaskRequest>, AddTaskValidation>();
            services.AddSingleton<IValidator<DeleteTaskRequest>, DeleteTaskValidaton>();
            services.AddSingleton<IValidator<UpdateTaskRequest>, UpdateTaskValidation>();
            services.AddSingleton<IValidator<ListTaskRequest>, ListTaskValidation>();
            services.AddSingleton<IValidator<GenerateReportRequest>, GenerateReportValidation>();

            services.AddSingleton<TaskLogService>();

            services.AddSingleton<TaskService>();

            services.AddSingleton<ITaskService>(sp =>
            {
                var service = sp.GetRequiredService<TaskService>();
                var logging = sp.GetRequiredService<TaskLogService>();
                var notification = sp.GetRequiredService<TaskNotificationService>();

                return new TaskServiceDecorator(service, logging, notification);
            });

            services.AddSingleton<TaskFacade>();
        }
    }
}
