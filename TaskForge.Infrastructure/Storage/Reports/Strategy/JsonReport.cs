using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using TaskForge.Core.Entity;
using TaskForge.Core.Interface.Report;
using TaskForge.Infrastructure.Serialization;

namespace TaskForge.Infrastructure.Storage.Reports.Strategy
{
    public class JsonReport : IReportStrategy
    {
        public string Format => "json";

        public byte[] Select(List<TaskBase> tasks)
        {
            return JsonSerializer.SerializeToUtf8Bytes(tasks, JsonOption.Options);
        }
    }
}