using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.App.Facade;

namespace TaskForge.Cli.Command
{
    public class UndoCommand(TaskFacade facade) : ICommand
    {
        private readonly TaskFacade _facade = facade;

        public string Name => "undo";

        public void Execute(string[] args)
        {
            _facade.Undo();
        }
    }
}

