using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using TaskForge.Application.DependencyInjection;
using TaskForge.UI.ViewModels;
using TaskForge.UI.Views;
using TaskForge.UI.Services;
using System;

namespace TaskForge.UI;

public partial class App : Avalonia.Application
{
    public static IServiceProvider? Services { get; private set; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var services = new ServiceCollection();

        TaskForgeCompositionRoot.AddTaskForge(services);

        services.AddSingleton<TaskUiService>();
        services.AddSingleton<MainWindowViewModel>();
        services.AddTransient<TasksPageViewModel>();

        Services = services.BuildServiceProvider();

        if (this.ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = Services.GetRequiredService<MainWindowViewModel>()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
