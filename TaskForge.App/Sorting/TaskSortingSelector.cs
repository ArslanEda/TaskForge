using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Core.Interface.Sorting;

namespace TaskForge.App.Sorting
{
    public class TaskSortingSelector(IEnumerable<ITaskSorting> strategies)
    {
        private readonly IEnumerable<ITaskSorting> _strategies = strategies;

        public ITaskSorting? Select(string? sort)
        {
            if (sort == null)
            {
                return null;
            }
            return _strategies.FirstOrDefault(s => s.Sorting.Equals(sort, StringComparison.OrdinalIgnoreCase));
        }
    }
}

