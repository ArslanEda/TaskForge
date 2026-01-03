using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.RequestModel;

namespace TaskForge.Application.Validation
{
    public class DeleteTaskValidaton : AbstractValidator<DeleteTaskRequest>
    {
        public DeleteTaskValidaton()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id must be greater than 0.");
        }
    }
}
