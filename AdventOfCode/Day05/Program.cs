using System;
using System.IO;
using System.Linq;

namespace Day05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            var lines = File.ReadAllLines("input1.txt");
            var hasVowelsRule = new HasVowelsRule();
            var hasAdjacentEqualLettersRule = new HasAdjacentEqualLettersRule();
            var doesNotHaveSubstringsRule = new NotRule(new HasSubstrings());
            var rules = new IRule[] {hasVowelsRule, hasAdjacentEqualLettersRule, doesNotHaveSubstringsRule,};
            var result = lines.Count(line => rules.All(x => x.Check(line)));
            Console.WriteLine(result);
        }

        private static void Part2()
        {
            var lines = File.ReadAllLines("input2.txt");
            var hasXyxRule = new HasXyxRule();
            var twoLettersAtLeastTwiceRule = new TwoLettersAtLeastTwiceRule();
            var rules = new IRule[] {hasXyxRule, twoLettersAtLeastTwiceRule,};

            var result = lines.Count(line => rules.All(x => x.Check(line)));
            Console.WriteLine(result);
        }
    }
}