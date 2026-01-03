using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Domain.ReportDomain
{
    public interface IReportStorage
    {
        void Save(Report report, byte[] content);
        IReadOnlyList<string> ListReports();
        string GetReportPath(string fileName);
    }
}
