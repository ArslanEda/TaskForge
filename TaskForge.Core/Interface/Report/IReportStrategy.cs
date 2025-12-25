using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;

namespace TaskForge.Core.Interface.Report
{
    public interface IReportStrategy
    {
        string Format { get; }
        byte[] Select(List<TaskBase> tasks);
    }
}


