using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Domain.ReportDomain;
using TaskForge.Infrastructure.FileSystem;

namespace TaskForge.Infrastructure.ReportStorage
{
    public class FileReportStorage(FilePathProvider pathProvider) : IReportStorage
    {
        private readonly FilePathProvider _pathProvider = pathProvider;

        public void Save(Report report, byte[] data)
        {
            var fileName = $"{report.FileName}.{report.Format}";
            var path = Path.Combine(_pathProvider.GetReportsFolder(), fileName);
            File.WriteAllBytes(path, data);
        }

        public IReadOnlyList<string> ListReports()
        {
            return Directory.GetFiles(_pathProvider.GetReportsFolder()).Select(Path.GetFileName).ToList()!;
        }

        public string GetReportPath(string fileName)
        {
            return Path.Combine(_pathProvider.GetReportsFolder(), fileName);
        }
    }
}

    
