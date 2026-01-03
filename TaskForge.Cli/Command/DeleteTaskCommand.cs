using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.Decorater;
using TaskForge.Application.RequestModel;

namespace TaskForge.Cli.Command
{
    public class DeleteTaskCommand(TaskFacadeDecorator facade) : ICommand
    {
        private readonly TaskFacadeDecorator _facade = facade;

        public string Name => "delete";

        public void Execute(string[] args)
        {
            var request = new DeleteTaskRequest
            {
                Id = args.GetInt("--id")
            };

            _facade.DeleteTask(request);
        }
    }
}
