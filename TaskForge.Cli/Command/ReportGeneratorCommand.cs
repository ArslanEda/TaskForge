using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.App.Facade;
using TaskForge.App.RequestModel;

namespace TaskForge.Cli.Command
{
    public class ReportCommand(TaskFacade facade) : ICommand
    {
        private readonly TaskFacade _facade = facade;

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

