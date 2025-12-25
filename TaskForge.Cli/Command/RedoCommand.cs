using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.App.Facade;

namespace TaskForge.Cli.Command
{
    public class RedoCommand(TaskFacade facade) : ICommand
    {
        private readonly TaskFacade _facade = facade;

        public string Name => "redo";

        public void Execute(string[] args)
        {
            _facade.Redo();
        }
    }
}