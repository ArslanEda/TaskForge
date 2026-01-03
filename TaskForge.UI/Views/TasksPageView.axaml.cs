using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using TaskForge.UI.ViewModels;

namespace TaskForge.UI.Views;

public partial class TasksPageView : UserControl
{
    public TasksPageView()
    {
        InitializeComponent();
        DataContext = App.Services!.GetRequiredService<TasksPageViewModel>();
    }
}