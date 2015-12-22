using System;
using System.Linq;

namespace Day05
{
    internal class HasSubstrings : IRule
    {
        private readonly string[] _substrings = {"ab", "cd", "pq", "xy"};

        public bool Check(string str)
        {
            return _substrings.Any(x => str.IndexOf(x, StringComparison.Ordinal) > -1);
        }
    }
}