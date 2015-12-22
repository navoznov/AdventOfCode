using System.Text.RegularExpressions;

namespace Day05
{
    /// <summary>
    /// It contains at least one letter which repeats with exactly one letter between them, like xyx, abcdefeghi (efe), or even aaa.
    /// </summary>
    class HasXyxRule : IRule
    {
        private Regex _regex = new Regex(@"(.).\1");

        public bool Check(string str)
        {
            return _regex.IsMatch(str);
        }
    }
}