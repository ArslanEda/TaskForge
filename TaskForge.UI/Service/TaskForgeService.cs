using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using TaskForge.Application.Facade;
using TaskForge.Application.RequestModel;
using TaskForge.UI.Models;

namespace TaskForge.UI.Services
{
    public class TaskUiService(TaskFacade facade)
    {
        private readonly TaskFacade _facade = facade;

        public List<TaskModel> List(string? sort)
        {
            var tasks = _facade.ListTasks(new ListTaskRequest
            {
                Sort = sort
            });

            return tasks.Select(t => new TaskModel
            {
                Id = t.Id,
                Type = t.Type,
                Title = t.Title,
                Priority = t.Priority,
                IsCompleted = t.IsCompleted,
                CreatedAt = t.CreatedAt,
            }).ToList();
        }

        public void Add(string type, string title, string priority)
        {
            _facade.AddTask(new AddTaskRequest
            {
                Type = type,
                Title = title,
                Priority = priority
            });
        }

        public void Delete(int id)
        {
            _facade.DeleteTask(new DeleteTaskRequest 
            { 
                Id = id 
            });
        }

        public void Update(int id, string type, string title, string priority, bool isCompleted)
        {
            _facade.UpdateTask(new UpdateTaskRequest
            {
                Id = id,
                Type = type,
                Title = title,
                Priority = priority,
                IsCompleted = isCompleted
            });
        }

        public void Undo()
        {
            _facade.Undo();
        }

        public void Redo()
        {
            _facade.Redo();
        }

        public List<string> GetUndoHistoryList()
        {
            return _facade.GetHistory();
        }

        public void GenerateReport(string format)
        {
            _facade.GenerateReport(new GenerateReportRequest
            {
                Format = format
            });
        }

        public IReadOnlyList<string> GetReportFiles()
        {
            return _facade.ListReports();
        }

        public void OpenReport(string fileName)
        {
            var fullPath = _facade.GetReportPath(fileName);

            if (!File.Exists(fullPath))
            {
                throw new FileNotFoundException("Report not found", fullPath);
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = fullPath,
                UseShellExecute = true
            });
        }
    }
}
