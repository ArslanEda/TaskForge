using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.Decorater;

namespace TaskForge.Cli.Command
{
    public class UndoCommand(TaskFacadeDecorator facade) : ICommand
    {
        private readonly TaskFacadeDecorator _facade = facade;

        public string Name => "undo";

        public void Execute(string[] args)
        {
            _facade.Undo();
        }
    }
}
