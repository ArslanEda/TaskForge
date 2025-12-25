using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.App.Report;
using TaskForge.App.RequestModel;
using TaskForge.App.Sorting;
using TaskForge.App.Validation;
using TaskForge.Core.Entity;
using TaskForge.Core.Service;
using TaskForge.Core.Interface.Service;

namespace TaskForge.App.Facade
{
    public class TaskFacade(IRequestValidaton validator, ITaskService taskService, TaskSnapshotService historyService, ReportService reportService, TaskSortingSelector sortingSelector)
    {
        private readonly IRequestValidaton _validator = validator;
        private readonly ITaskService _taskService = taskService;
        private readonly ReportService _reportService = reportService;
        private readonly TaskSnapshotService _historyService = historyService;
        private readonly TaskSortingSelector _sortingSelector = sortingSelector;

        public List<TaskBase> ListTask(ListTaskRequest request)
        {
            _validator.Validate(request);
            var tasks = _taskService.ListTask();
            return _sortingSelector.Select(request.Sort)?.Sort(tasks) ?? tasks;
        }

        public TaskBase AddTask(AddTaskRequest request)
        {
            _validator.Validate(request);
            var task = _taskService.AddTask(request.Type, request.Title, request.Priority);
            return task;
        }

        public void UpdateTask(UpdateTaskRequest request)
        {
            _validator.Validate(request);
            _taskService.UpdateTask(request.Id, request.Type, request.Title, request.Priority, request.IsCompleted);
        }

        public void DeleteTask(DeleteTaskRequest request)
        {
            _validator.Validate(request);
            _taskService.DeleteTask(request.Id);
        }

        public TaskBase? Undo()
        {
            return _taskService.Undo();
        }

        public TaskBase? Redo()
        {
            return _taskService.Redo();
        }

        public void GenerateReport(GenerateReportRequest request)
        {
            _reportService.GenerateReport(request);
        }

        public IReadOnlyList<string> GetReportFiles()
        {
            return _reportService.GetReportFiles();
        }

        public void OpenReport(string fileName)
        {
            _reportService.OpenReport(fileName);
        }

        public List<string> GetUndoHistory()
        {
            return _historyService.GetUndoHistory();
        }
    }
}