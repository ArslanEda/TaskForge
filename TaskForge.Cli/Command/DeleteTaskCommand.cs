using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.App.Facade;
using TaskForge.App.RequestModel;

namespace TaskForge.Cli.Command
{
    public class DeleteTaskCommand(TaskFacade facade) : ICommand
    {
        private readonly TaskFacade _facade = facade;

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

