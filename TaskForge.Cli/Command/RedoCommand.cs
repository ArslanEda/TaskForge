using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.Decorater;

namespace TaskForge.Cli.Command
{
    public class RedoCommand(TaskFacadeDecorator facade) : ICommand
    {
        private readonly TaskFacadeDecorator _facade = facade;

        public string Name => "redo";

        public void Execute(string[] args)
        {
            _facade.Redo();
        }
    }
}
