using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TaskForge.Application.RequestModel;

namespace TaskForge.Application.Validation
{
    public class AddTaskValidation : AbstractValidator<AddTaskRequest>
    {
        public AddTaskValidation()
        {
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
