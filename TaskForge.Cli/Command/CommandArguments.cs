using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForge.Cli.Command
{
    public static class CommandArguments
    {
        public static string Get(this string[] args, string key)
        {
            int index = Array.IndexOf(args, key);
            return index >= 0 && index + 1 < args.Length ? args[index + 1] : "";
        }

        public static int GetInt(this string[] args, string key)
        {
            return int.TryParse(args.Get(key), out var i) ? i : 0;
        }

        public static bool GetBool(this string[] args, string key)
        {
            return bool.TryParse(args.Get(key), out var b) && b;
        }
    }
}
