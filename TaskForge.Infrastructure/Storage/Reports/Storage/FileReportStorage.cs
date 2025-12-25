using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Interface.Infrastructure;
using TaskForge.Core.Interface.Report;

namespace TaskForge.Infrastructure.Storage.Reports.Storage
{
    public class FileReportStorage(IPathProvider pathProvider) : IReportStorage
    {
        private readonly IPathProvider _pathProvider = pathProvider;

        public void Save(string filePath, byte[] content)
        {
            File.WriteAllBytes(filePath, content);
        }

        public IReadOnlyList<string> GetReportFiles()
        {
            var path = _pathProvider.GetReportsFolder();

            return Directory.GetFiles(path).Select(Path.GetFileName).Where(f => f != null).ToList()!;
        }

        public void OpenReport(string fileName)
        {
            var path = Path.Combine(_pathProvider.GetReportsFolder(), fileName);

            Process.Start(new ProcessStartInfo
            {
                FileName = path,
                UseShellExecute = true
            });
        }
    }
}
