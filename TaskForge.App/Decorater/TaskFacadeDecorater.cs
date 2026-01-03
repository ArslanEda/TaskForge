using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task = TaskForge.Domain.TaskDomain.Task;
using TaskForge.Application.Facade;
using TaskForge.Application.RequestModel;
using TaskForge.Application.Validation;
using TaskForge.Domain.LoggingDomain;
using TaskForge.Domain.NotificationDomain;

namespace TaskForge.Application.Decorater
{
    public class TaskFacadeDecorator(TaskFacade inner, IRequestValidaton validation, LogService logService, NotificationService notificationService)
    {
        private readonly TaskFacade _inner = inner;
        private readonly IRequestValidaton _validation = validation;
        private readonly LogService _logService = logService;
        private readonly NotificationService _notificationService = notificationService;

        public List<Task> ListTasks(ListTaskRequest request)
        {
            return _inner.ListTasks(request);
        }

        public Task AddTask(AddTaskRequest request)
        {
            try
            {
                _validation.Validate(request);
                var task = _inner.AddTask(request);
                _logService.AddLog("AddTask", $"Added [{task.Id}]", "Success");
                _notificationService.Notify("Task added", task.Title);

                return task;
            }
            catch (Exception ex)
            {
                _logService.AddLog("AddTask", ex.Message, "Failed");
                throw;
            }
        }

        public void UpdateTask(UpdateTaskRequest request)
        {
            try
            {
                _validation.Validate(request);
                _inner.UpdateTask(request);
                _logService.AddLog("UpdateTask", $"Updated [{request.Id}]", "Success");
                _notificationService.Notify("Task updated", request.Title);
            }
            catch (Exception ex)
            {
                _logService.AddLog("UpdateTask", ex.Message, "Failed");
                throw;
            }
        }

        public void DeleteTask(DeleteTaskRequest request)
        {
            try
            {
                _validation.Validate(request);
                _inner.DeleteTask(request);
                _logService.AddLog("DeleteTask", $"Deleted [{request.Id}]", "Success");
                _notificationService.Notify("Task deleted", request.Id.ToString());
            }
            catch (Exception ex)
            {
                _logService.AddLog("DeleteTask", ex.Message, "Failed");
                throw;
            }
        }

        public Task? Undo()
        {
            try
            {
                var task = _inner.Undo();

                if (task != null)
                {
                    _logService.AddLog("Undo", $"Undo [{task.Id}]", "Success");
                    _notificationService.Notify("Undo", task.Title);
                }

                return task;
            }
            catch (Exception ex)
            {
                _logService.AddLog("Undo", ex.Message, "Failed");
                throw;
            }
        }

        public Task? Redo()
        {
            try
            {
                var task = _inner.Redo();

                if (task != null)
                {
                    _logService.AddLog("Redo", $"Redo [{task.Id}]", "Success");
                    _notificationService.Notify("Redo", task.Title);
                }

                return task;
            }
            catch (Exception ex)
            {
                _logService.AddLog("Redo", ex.Message, "Failed");
                throw;
            }
        }

        public void GenerateReport(GenerateReportRequest request)
        {
            try
            {
                _validation.Validate(request);
                _inner.GenerateReport(request);
                _logService.AddLog("GenerateReport", request.Format, "Success");
                _notificationService.Notify("Report generated", request.Format);
            }
            catch (Exception ex)
            {
                _logService.AddLog("GenerateReport", ex.Message, "Failed");
                throw;
            }
        }
    }
}
