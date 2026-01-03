using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.RequestModel;

namespace TaskForge.Application.Validation
{
    public class UpdateTaskValidation : AbstractValidator<UpdateTaskRequest>
    {
        public UpdateTaskValidation()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("Type cannot be empty.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty.");

            RuleFor(x => x.Priority)
                .Must(p => p is "low" or "medium" or "high")
                .WithMessage("Priority can only be Low, Medium or High.");
        }
    }
}
