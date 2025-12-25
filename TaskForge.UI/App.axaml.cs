using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using TaskForge.UI.ViewModels;
using TaskForge.UI.Views;
using TaskForge.App.DependencyInjection;
using TaskForge.UI.Services;

namespace TaskForge.UI
{
    public partial class App : Application
    {
        public static IServiceProvider? Services { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            var services = new ServiceCollection();
            TaskForgeDependency.AddServices(services);

            services.AddSingleton<TaskUiService>();
            services.AddSingleton<MainWindowViewModel>();
            services.AddTransient<TasksPageViewModel>();

            Services = services.BuildServiceProvider();

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = Services.GetRequiredService<MainWindowViewModel>()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}

