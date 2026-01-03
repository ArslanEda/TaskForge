using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Infrastructure.FileSystem
{
    public class FilePathProvider
    {
        private readonly string _rootPath = @"D:\TaskForge\TaskForge.Storage";

        private static string EnsureFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
            return folder;
        }

        public string GetDataFolder()
        {
            return EnsureFolder(Path.Combine(_rootPath, "Data"));
        }

        public string GetReportsFolder()
        {
            return EnsureFolder(Path.Combine(_rootPath, "Reports"));
        }

        public string GetLogsFolder()
        {
            return EnsureFolder(Path.Combine(_rootPath, "Log"));
        }

        public string GetHistoryFolder()
        {
            return EnsureFolder(Path.Combine(_rootPath, "Memento"));
        }
    }
}