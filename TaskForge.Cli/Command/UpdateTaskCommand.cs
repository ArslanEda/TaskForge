using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.Decorater;
using TaskForge.Application.RequestModel;

namespace TaskForge.Cli.Command
{
    public class UpdateTaskCommand(TaskFacadeDecorator facade) : ICommand
    {
        private readonly TaskFacadeDecorator _facade = facade;

        public string Name => "update";
        public void Execute(string[] args)
        {
            var request = new UpdateTaskRequest
            {
                Id = args.GetInt("--id"),
                Type = args.Get("--type"),
                Title = args.Get("--title"),
                Priority = args.Get("--priority"),
                IsCompleted = args.GetBool("--completed")
            };

            _facade.UpdateTask(request);
        }
    }
}
