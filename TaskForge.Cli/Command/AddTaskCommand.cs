using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskForge.App.Facade;
using TaskForge.App.RequestModel;

namespace TaskForge.Cli.Command
{
    public class AddTaskCommand(TaskFacade facade) : ICommand
    {
        private readonly TaskFacade _facade = facade;

        public string Name => "add";

        public void Execute(string[] args)
        {
            var request = new AddTaskRequest
            {
                Type = args.Get("--type"),
                Title = args.Get("--title"),
                Priority = args.Get("--priority")
            };

            _facade.AddTask(request);
        }
    }
}