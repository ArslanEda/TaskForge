using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.App.Facade;
using TaskForge.App.RequestModel;

namespace TaskForge.Cli.Command
{
    public class ListTaskCommand(TaskFacade facade) : ICommand
    {
        private readonly TaskFacade _facade = facade;

        public string Name => "list";

        public void Execute(string[] args)
        {
            var request = new ListTaskRequest
            {
                Sort = args.Get("--sort")
            };

            var tasks = _facade.ListTask(request);

            foreach (var t in tasks)
            {
                Console.WriteLine($"[{t.Id}] - {t.Type} | {t.Title} | {t.Priority} | {t.IsCompleted}");
            }
        }
    }
}
