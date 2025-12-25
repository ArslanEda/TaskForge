using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Core.Interface.Report
{
    public interface IReportStorage
    {
        void Save(string path, byte[] content);
        IReadOnlyList<string> GetReportFiles();
        void OpenReport(string fileName);
    }
}
