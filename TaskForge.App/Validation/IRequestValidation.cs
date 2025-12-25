using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.App.Validation
{
    public interface IRequestValidaton
    {
        void Validate<TRequest>(TRequest request);
    }

}
