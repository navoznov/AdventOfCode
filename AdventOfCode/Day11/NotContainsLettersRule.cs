using System.Text.RegularExpressions;

namespace Day11
{
    /// <summary>
    /// Passwords may not contain the letters i, o, or l, as these letters can be mistaken for other characters and are therefore confusing.
    /// </summary>
    internal class NotContainsLettersRule : IRule
    {
        public bool Check(string str)
        {
            return !Regex.IsMatch(str, @"[iol]");
        }
    }
}