using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TaskForge.UI.Models;
using TaskForge.UI.Services;
using TaskForge.UI.Validation;

namespace TaskForge.UI.ViewModels
{
    public partial class TasksPageViewModel : ViewModelBase
    {
        private readonly TaskUiService _taskService;

        public TasksPageViewModel(TaskUiService taskService)
        {
            _taskService = taskService;

            LoadTasks();
            LoadUndoHistory();
            LoadReports();
        }

        [ObservableProperty]
        private ObservableCollection<TaskModel> tasks = [];

        public string[] SortOptions { get; } = ["Sort", "date", "priority"];

        [ObservableProperty]
        private string selectedSort = "Sort";

        partial void OnSelectedSortChanged(string value)
        {
            LoadTasks();
        }

        private void LoadTasks()
        {
            Tasks = new ObservableCollection<TaskModel>(_taskService.List(SelectedSort == "Sort" ? null : SelectedSort));
            OnPropertyChanged(nameof(FilteredItems));
        }

        [ObservableProperty]
        private string? searchText;

        public IEnumerable<TaskModel> FilteredItems =>
            Tasks.Where(t =>
            (
            string.IsNullOrWhiteSpace(SearchText) ||
            t.Title.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
            t.Type.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
            t.Priority != null && t.Priority.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
            ));

        partial void OnSearchTextChanged(string? value)
        {
            OnPropertyChanged(nameof(FilteredItems));
            LoadTasks();
        }

        [RelayCommand]
        public void Edit(TaskModel task)
        {
            foreach (var t in Tasks)
            {
                t.IsEditMode = false;
            }

            task.IsEditMode = true;
        }

        [RelayCommand]
        public void Save(TaskModel task)
        {
            var error = TaskForgeValidation.ValidateEdit(task.Type, task.Title, task.Priority);

            if (error != null)
            {
                PopupMessage = error;
                PopupOpen = true;
                return;
            }

            _taskService.Update(task.Id, task.Type, task.Title, task.Priority, task.IsCompleted);
            task.IsEditMode = false;
            LoadTasks();
            LoadUndoHistory();
        }

        [RelayCommand]
        public void Cancel(TaskModel task)
        {
            task.IsEditMode = false;
            LoadTasks();
        }

        [ObservableProperty]
        private string type = "";

        [ObservableProperty]
        private string title = "";

        public string[] Priorities { get; } = ["Priority", "low", "medium", "high"];

        [ObservableProperty]
        private string selectedPriority = "Priority";

        [ObservableProperty]
        private string? addErrorMessage;

        [RelayCommand]
        public void AddTask()
        {
            var error = TaskForgeValidation.ValidateAdd(Type, Title, SelectedPriority);

            if (error != null)
            {
                AddErrorMessage = error;
                return;
            }

            _taskService.Add(Type, Title, SelectedPriority);

            Type = "";
            Title = "";
            SelectedPriority = "Priority";
            AddErrorMessage = null;

            LoadTasks();
            LoadUndoHistory();
        }

        [RelayCommand]
        public void DeleteTask(TaskModel task)
        {
            _taskService.Delete(task.Id);
            LoadTasks();
            LoadUndoHistory();
        }

        public IReadOnlyList<string> Formats { get; } = ["Format", "json", "xlsx", "pdf"];

        [ObservableProperty]
        private string selectedFormat = "Format";

        [ObservableProperty]
        private List<string> reportFiles = [];

        private void LoadReports()
        {
            ReportFiles = _taskService.GetReportFiles().ToList();
        }

        [RelayCommand]
        public void GenerateReport()
        {
            var error = TaskForgeValidation.ValidateReport(SelectedFormat);

            if (error != null)
            {
                PopupMessage = error;
                PopupOpen = true;
                return;
            }

            _taskService.GenerateReport(SelectedFormat);
            LoadReports();
        }

        [RelayCommand]
        public void OpenReport(string fileName)
        {
            _taskService.OpenReport(fileName);
        }

        public ObservableCollection<string> UndoHistory { get; } = [];

        private void LoadUndoHistory()
        {
            UndoHistory.Clear();
            foreach (var item in _taskService.GetUndoHistoryList())
            {
                UndoHistory.Add(item);
            }
        }

        [RelayCommand]
        public void Undo()
        {
            _taskService.Undo();
            LoadTasks();
            LoadUndoHistory();
        }

        [RelayCommand]
        public void Redo()
        {
            _taskService.Redo();
            LoadTasks();
            LoadUndoHistory();
        }

        [ObservableProperty]
        private string popupMessage = "";

        [ObservableProperty]
        private bool popupOpen;

        [RelayCommand]
        public void ClosePopup()
        {
            PopupOpen = false;
        }
    }
}