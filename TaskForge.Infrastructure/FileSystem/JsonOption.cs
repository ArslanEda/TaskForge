using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TaskForge.Infrastructure.FileSystem
{
    public static class JsonOption
    {
        public static readonly JsonSerializerOptions Options = new()
        {
            WriteIndented = true
        };
    }
}
