using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace TaskForge.Application.Validation
{
    public class RequestValidaton(IServiceProvider provider) : IRequestValidaton
    {
        public void Validate<TRequest>(TRequest request)
        {
            var validator = provider.GetRequiredService<IValidator<TRequest>>();
            validator.ValidateAndThrow(request);
        }
    }
}
