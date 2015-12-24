using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day19
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            List<ReplacementRule> replacementRules;
            string moleculeStr;
            Parse(lines, out replacementRules, out moleculeStr);
            
            var combinations = GetCombinations(moleculeStr, replacementRules);
            Console.WriteLine(combinations.Count());
        }

        private static IEnumerable<string> GetCombinations(string moleculeStr, IEnumerable<ReplacementRule> replacementRules)
        {
            var result = new List<string>().AsEnumerable();
            foreach (var rule in replacementRules)
            {
                var combinations = GetCombinationsForRule(moleculeStr, rule);
                result = result.Union(combinations);
            }
            return result;
        }

        private static IEnumerable<string> GetCombinationsForRule(string moleculeStr, ReplacementRule replacementRule)
        {
            var index = 0;
            var source = replacementRule.Source;
            var sourceStrLength = source.Length;
            do
            {
                index = moleculeStr.IndexOf(source, index, StringComparison.Ordinal);
                if (index == -1)
                {
                    break;
                }
                var sb = new StringBuilder(moleculeStr);
                sb.Replace(source, replacementRule.Target, index, sourceStrLength);
                var combination = sb.ToString();
                yield return combination;
                index +=sourceStrLength;
            } while (true);
        }

        private static void Parse(string[] lines, out List<ReplacementRule> replacementRules, out string moleculeStr)
        {
            replacementRules = ParseReplacementRules(lines).ToList();
            moleculeStr = lines.Last();
        }

        private static IEnumerable<string> ParseMoleculeComponents(string moleculeStr)
        {
            var regex = new Regex(@"([A-Z][a-z]*)+");
            return regex.Match(moleculeStr).Groups[1].Captures.Cast<Capture>().Select(x => x.Value);
        }

        private static IEnumerable<ReplacementRule> ParseReplacementRules(string[] lines)
        {
            var replacementRegex = new Regex(@"(?<source>[A-Z]?[a-z]*) =\> (?<target>[A-Za-z]+)");
            var replacementLines = lines.Take(lines.Length - 2);

            foreach (var replacementLine in replacementLines)
            {
                var match = replacementRegex.Match(replacementLine);
                var source = match.Groups["source"].Value;
                var target = match.Groups["target"].Value;
                yield return new ReplacementRule(source, target);
            }
        }
    }
}