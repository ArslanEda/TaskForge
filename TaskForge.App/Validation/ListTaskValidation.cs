using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.RequestModel;

namespace TaskForge.Application.Validation
{
    public class ListTaskValidation : AbstractValidator<ListTaskRequest>
    {
        public ListTaskValidation()
        {
            RuleFor(x => x.Sort)
                .Must(s => s is null or "date" or "priority")
                .WithMessage("Sort can be 'date' or 'priority'.");
        }
    }
}
