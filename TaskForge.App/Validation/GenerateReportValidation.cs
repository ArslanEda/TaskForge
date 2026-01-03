using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.Application.RequestModel;

namespace TaskForge.App.Validation
{
    public class GenerateReportValidation : AbstractValidator<GenerateReportRequest>
    {
        public GenerateReportValidation()
        {
            RuleFor(x => x.Format)
                .NotEmpty().WithMessage("Format is required")
                .Must(f => f is "pdf" or "json" or "xlsx")
                .WithMessage("Valid formats: pdf, json, xlsx.");
        }
    }
}
