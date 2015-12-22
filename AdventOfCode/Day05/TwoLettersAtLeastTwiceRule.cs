using System.Text.RegularExpressions;

namespace Day05
{
    /// <summary>
    /// It contains a pair of any two letters that appears at least twice in the string without overlapping, like xyxy (xy) or aabcdefgaa (aa), but not like aaa (aa, but it overlaps).
    /// </summary>
    class TwoLettersAtLeastTwiceRule : IRule
    {
        private Regex _regex = new Regex(@".*(.)(.).*\1\2.*");

        public bool Check(string str)
        {
            return _regex.IsMatch(str);
        }
    }
}