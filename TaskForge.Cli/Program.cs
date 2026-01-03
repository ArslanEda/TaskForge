using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using TaskForge.Application.DependencyInjection;
using TaskForge.Cli.Command;

namespace TaskForge
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var services = new ServiceCollection();

            TaskForgeCompositionRoot.AddTaskForge(services);

            services.AddSingleton<ICommand, AddTaskCommand>();
            services.AddSingleton<ICommand, UpdateTaskCommand>();
            services.AddSingleton<ICommand, DeleteTaskCommand>();
            services.AddSingleton<ICommand, ListTaskCommand>();
            services.AddSingleton<ICommand, UndoCommand>();
            services.AddSingleton<ICommand, RedoCommand>();
            services.AddSingleton<ICommand, ReportCommand>();

            var provider = services.BuildServiceProvider();

            string action = args.Length > 0 ? args[0].ToLower() : "";

            var commands = provider.GetServices<ICommand>().ToDictionary(c => c.Name, c => c);

            if (!commands.TryGetValue(action, out var command))
            {
                Console.WriteLine("Invalid action. Use: add, delete, update, list, undo, redo, report");
                ShowUsageGuide();
                return;
            }

            try
            {
                command.Execute(args);
            }
            catch (ValidationException ex)
            {
                Console.WriteLine("Validation errors:");
                foreach (var e in ex.Errors)
                {
                    Console.WriteLine($" - {e.ErrorMessage}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void ShowUsageGuide()
        {
            Console.WriteLine("Usage examples:");
            Console.WriteLine(" dotnet run list");
            Console.WriteLine(" dotnet run list --sort date or priority");
            Console.WriteLine(" dotnet run add --type bug --title login error --priority high");
            Console.WriteLine(" dotnet run delete --id 1");
            Console.WriteLine(" dotnet run update --id 1 --type bug --title fixed login --priority medium --completed true");
            Console.WriteLine(" dotnet run report --format pdf");
            Console.WriteLine(" dotnet run undo");
            Console.WriteLine(" dotnet run redo");
        }
    }
}