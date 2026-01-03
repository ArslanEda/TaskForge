using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskForge.Application.RequestModel;
using TaskForge.Domain.ReportDomain;
using TaskForge.Domain.TaskDomain;
using TaskForge.Domain.TaskDomain.Memento;
using TaskForge.Domain.TaskDomain.Sorting;
using Task = TaskForge.Domain.TaskDomain.Task;

namespace TaskForge.Application.Facade
{
    public class TaskFacade(TaskService taskService, TaskCaretakerService historyService, ReportService reportService, IEnumerable<ITaskSortByStrategy> sortingStrategy, IEnumerable<IReportStrategy> reportStrategy) 
    {
        private readonly TaskService _taskService = taskService;
        private readonly TaskCaretakerService _historyService = historyService;
        private readonly ReportService _reportService = reportService;
        private readonly IEnumerable<ITaskSortByStrategy> _sortingStrategy = sortingStrategy;
        private readonly IEnumerable<IReportStrategy> _reportStrategy = reportStrategy;

        public List<Task> ListTasks(ListTaskRequest request)
        {
            var tasks = _taskService.ListTask();
            var sorter = _sortingStrategy.FirstOrDefault(s => s.Sorting == request.Sort);
            return sorter?.Sort(tasks) ?? tasks;
        }

        public Task AddTask(AddTaskRequest request)
        {
            var task = _taskService.AddTask(request.Type, request.Title, request.Priority);
            _historyService.Save(null, task);
            return task;
        }

        public void DeleteTask(DeleteTaskRequest request)
        {
            var task = _taskService.DeleteTask(request.Id);
            _historyService.Save(task, null);
        }

        public void UpdateTask(UpdateTaskRequest request)
        {
            var before = _taskService.ListTask().First(t => t.Id == request.Id).Clone();
            var after = _taskService.UpdateTask(request.Id, request.Type, request.Title, request.Priority, request.IsCompleted);
            _historyService.Save(before, after);
        }

        public Task? Undo()
        {
            var memento = _historyService.Undo();
            if (memento == null)
            {
                return null;
            }

            if (memento.Before == null && memento.After != null)
            {
                _taskService.DeleteTask(memento.After.Id);
                return memento.After;
            }

            if (memento.Before != null && memento.After == null)
            {
                _taskService.AddTask(memento.Before.Type, memento.Before.Title, memento.Before.Priority);
                return memento.Before;
            }

            _taskService.UpdateTask(memento.Before!.Id, memento.Before.Type, memento.Before.Title, memento.Before.Priority, memento.Before.IsCompleted);
            return memento.Before;
        }

        public Task? Redo()
        {
            var memento = _historyService.Redo();
            if (memento == null)
            {
                return null;
            }

            if (memento.Before == null && memento.After != null)
            {
                _taskService.AddTask(memento.After.Type, memento.After.Title, memento.After.Priority);
                return memento.After;
            }

            if (memento.Before != null && memento.After == null)
            {
                _taskService.DeleteTask(memento.Before.Id);
                return memento.Before;
            }

            _taskService.UpdateTask(memento.After!.Id, memento.After.Type, memento.After.Title, memento.After.Priority, memento.After.IsCompleted);
            return memento.After;
        }


        public void GenerateReport(GenerateReportRequest request)
        {
            var items = _taskService.ListTask().Select(t => new ReportTaskItem(t.Id, t.Type, t.Title, t.Priority, t.IsCompleted, t.CreatedAt));
            var strategy = _reportStrategy.First(s => s.Format == request.Format);
            _reportService.GenerateReport(items, strategy);
        }

        public IReadOnlyList<string> ListReports()
        {
            return _reportService.ListReports();
        }

        public string GetReportPath(string fileName)
        {
            return _reportService.GetReportPath(fileName);
        }
        public List<string> GetHistory()
        {
            return _historyService.GetHistory();
        }
    }
}
