using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskForge.UI.Models;

namespace TaskForge.UI.Validation
{
    public static class TaskForgeValidation
    {
        public static string? ValidateAdd(string type, string title, string priority)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return "Type is required.";
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                return "Title is required.";
            }

            if (priority == "Priority")
            {
                return "Please select a priority.";
            }

            return null;
        }

        public static string? ValidateEdit(string type, string title, string priority)
        {
            if (string.IsNullOrWhiteSpace(type))
            {
                return "Type is required.";
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                return "Title is required.";
            }

            if (string.IsNullOrWhiteSpace(priority))
            {
                return "Priority is required.";
            }

            return null;
        }


        public static string? ValidateReport(string format)
        {
            if (format == "Format")
            {
                return "Please select a report format.";
            }

            return null;
        }
    }
}

