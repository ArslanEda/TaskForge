using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.Decorater;
using TaskForge.Application.RequestModel;

namespace TaskForge.Cli.Command
{
    public class ReportCommand(TaskFacadeDecorator facade) : ICommand
    {
        private readonly TaskFacadeDecorator _facade = facade;

        public string Name => "report";

        public void Execute(string[] args)
        {
            var request = new GenerateReportRequest
            {
                Format = args.Get("--format")
            };

            _facade.GenerateReport(request);
        }
    }
}
