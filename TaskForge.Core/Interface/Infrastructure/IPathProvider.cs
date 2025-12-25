using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Core.Interface.Infrastructure
{
    public interface IPathProvider
    {
        string GetDataFolder();
        string GetReportsFolder();
        string GetLogsFolder();
        string GetHistoryFolder();
    }
}
