using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Entity;

namespace TaskForge.Core.Interface.Sorting
{
    public interface ITaskSorting
    {
        string Sorting { get; }
        List<TaskBase> Sort(List<TaskBase> tasks);
    }
}
