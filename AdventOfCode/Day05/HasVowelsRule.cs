using System.Linq;

namespace Day05
{
    internal class HasVowelsRule : IRule
    {
        private readonly int _minVowelsCount = 3;
        private readonly char[] _vowels = "aeiou".ToCharArray();

        public bool Check(string str)
        {
            var vowelsCountInStr = str.ToCharArray().Count(x => _vowels.Contains(x));
            return vowelsCountInStr >= _minVowelsCount;
        }
    }
}