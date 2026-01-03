using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.ReportDomain
{
    public class ReportFactory
    {
        public Report Create(string format)
        {
            return new Report
            {
                FileName = $"{DateTime.Now:dd.MM.yyyy_HH.mm}",
                Format = format,
            };
        }
    }
}
