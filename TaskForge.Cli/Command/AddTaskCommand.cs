using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.Decorater;
using TaskForge.Application.RequestModel;

namespace TaskForge.Cli.Command
{
    public class AddTaskCommand(TaskFacadeDecorator facade) : ICommand
    {
        private readonly TaskFacadeDecorator _facade = facade;

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
