using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TaskForge.App.Validation;
using TaskForge.Application.Decorater;
using TaskForge.Application.Facade;
using TaskForge.Application.RequestModel;
using TaskForge.Application.Validation;
using TaskForge.Domain.LoggingDomain;
using TaskForge.Domain.NotificationDomain;
using TaskForge.Domain.ReportDomain;
using TaskForge.Domain.TaskDomain;
using TaskForge.Domain.TaskDomain.Memento;
using TaskForge.Domain.TaskDomain.Sorting;
using TaskForge.Domain.Tasks.Sorting;
using TaskFactory = TaskForge.Domain.TaskDomain.TaskFactory;
using TaskForge.Infrastructure.FileSystem;
using TaskForge.Infrastructure.HistoryFile;
using TaskForge.Infrastructure.Logging;
using TaskForge.Infrastructure.ReportStorage.Strategy;
using TaskForge.Infrastructure.ReportStorage;
using TaskForge.Infrastructure.TaskFile;
using TaskForge.Infrastructure.Tasks.Sorting;


namespace TaskForge.Application.DependencyInjection
{
    public static class TaskForgeCompositionRoot
    {
        public static void AddTaskForge(IServiceCollection services)
        {
            services.AddSingleton<FilePathProvider>();

            services.AddSingleton<TaskStorage>();
            services.AddSingleton<TaskFactory>();
            services.AddSingleton<ITaskRepository, TaskRepository>();
            services.AddSingleton<TaskService>();

            services.AddSingleton<ITaskHistoryStorage, TaskHistoryStorage>();
            services.AddSingleton<TaskCaretakerService>();

            services.AddSingleton<ITaskSortByStrategy, SortByCreatedDate>();
            services.AddSingleton<ITaskSortByStrategy, SortByPriority>();

            services.AddSingleton<LogStorage>();
            services.AddSingleton<LogFactory>();
            services.AddSingleton<ITaskLogRepository, LogRepository>();
            services.AddSingleton<LogService>();

            services.AddSingleton<ReportFactory>();
            services.AddSingleton<IReportStorage, FileReportStorage>();
            services.AddSingleton<ReportService>();
            services.AddSingleton<IReportStrategy, JsonReportGenerator>();
            services.AddSingleton<IReportStrategy, PdfReportGenerator>();
            services.AddSingleton<IReportStrategy, XlsxReportGenerator>();

            services.AddSingleton<INotificationObserver, ConsoleNotificationObserver>();
            services.AddSingleton<NotificationService>();

            services.AddSingleton<IRequestValidaton, RequestValidaton>();
            services.AddSingleton<IValidator<AddTaskRequest>, AddTaskValidation>();
            services.AddSingleton<IValidator<DeleteTaskRequest>, DeleteTaskValidaton>();
            services.AddSingleton<IValidator<GenerateReportRequest>, GenerateReportValidation>();
            services.AddSingleton<IValidator<UpdateTaskRequest>, UpdateTaskValidation>();
            services.AddSingleton<IValidator<ListTaskRequest>, ListTaskValidation>();

            services.AddSingleton<TaskFacade>();

            services.AddSingleton<TaskFacadeDecorator>();
        }
    }
}