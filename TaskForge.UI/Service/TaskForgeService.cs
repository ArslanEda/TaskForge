using System.Collections.Generic;
using System.Linq;
using TaskForge.App.Facade;
using TaskForge.App.RequestModel;
using TaskForge.UI.Models;

namespace TaskForge.UI.Services
{
    public class TaskUiService(TaskFacade facade)
    {
        private readonly TaskFacade _facade = facade;

        public List<TaskModel> List(string? sort)
        {
            var tasks = _facade.ListTask(new ListTaskRequest
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
            return _facade.GetUndoHistory();
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
            return _facade.GetReportFiles();
        }

        public void OpenReport(string fileName)
        {
            _facade.OpenReport(fileName);
        }
    }
}
