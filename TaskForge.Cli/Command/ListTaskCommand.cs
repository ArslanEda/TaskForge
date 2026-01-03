using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.Decorater;
using TaskForge.Application.RequestModel;

namespace TaskForge.Cli.Command
{
    public class ListTaskCommand(TaskFacadeDecorator facade) : ICommand
    {
        private readonly TaskFacadeDecorator _facade = facade;

        public string Name => "list";

        public void Execute(string[] args)
        {
            var request = new ListTaskRequest
            {
                Sort = args.Get("--sort")
            };

            var tasks = _facade.ListTasks(request);

            foreach (var t in tasks)
            {
                Console.WriteLine($"[{t.Id}] - {t.Type} | {t.Title} | {t.Priority} | {t.IsCompleted}");
            }
        }
    }
}
