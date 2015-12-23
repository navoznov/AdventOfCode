using System.Linq;
using System.Text.RegularExpressions;

namespace Day11
{
    /// <summary>
    /// Passwords must contain at least two different, non-overlapping pairs of letters, like aa, bb, or zz.
    /// </summary>
    internal class HasTwoLettersPairsRule : IRule
    {
        public bool Check(string str)
        {
            var regex = new Regex(@"(\w)\1");
            return regex.Matches(str).Cast<Match>().Select(x => x.Value).Distinct().Count() >= 2;
        }
    }
}