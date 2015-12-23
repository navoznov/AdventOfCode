using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day16
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");

            var sues = ParseSues(lines);

            var patternSueParams = new Dictionary<string, int>
            {
                {"children", 3},
                {"cats", 7},
                {"samoyeds", 2},
                {"pomeranians", 3},
                {"akitas", 0},
                {"vizslas", 0},
                {"goldfish", 5},
                {"trees", 3},
                {"cars", 2},
                {"perfumes", 1},
            };
            Part1(sues, patternSueParams);
            Part2(sues, patternSueParams);
        }

        private static void Part1(List<Sue> sues, Dictionary<string, int> patternSueParams)
        {
            var filteredSues = sues.ToList();
            foreach (var param in patternSueParams)
            {
                filteredSues =
                    filteredSues.Where(x => !x.Params.ContainsKey(param.Key) || x.Params[param.Key] == param.Value)
                        .ToList();
            }
            Console.WriteLine(filteredSues.Single().Number);
        }

        private static void Part2(List<Sue> sues, Dictionary<string, int> patternSueParams)
        {
            var graterParamNames = new List<string> {"cats", "trees"};
            var fewerParamNames = new List<string> {"pomeranians", "goldfish"};
            var filteredSues = sues.ToList();
            foreach (var param in patternSueParams)
            {
                filteredSues = filteredSues.Where(x => CheckParam(x, param, graterParamNames, fewerParamNames)).ToList();
            }
            foreach (var filteredSue in filteredSues)
            {
                Console.WriteLine(filteredSue.Number);
            }
        }

        private static bool CheckParam(Sue sue, KeyValuePair<string, int> patternParam, List<string> graterParamNames,
            List<string> fewerParamNames)
        {
            var patternParamName = patternParam.Key;
            if (!sue.Params.ContainsKey(patternParamName))
            {
                return true;
            }
            var paramValue = sue.Params[patternParamName];
            var patternParamValue = patternParam.Value;
            if (graterParamNames.Contains(patternParamName) && paramValue > patternParamValue)
            {
                return true;
            }
            if (fewerParamNames.Contains(patternParamName) && paramValue < patternParamValue)
            {
                return true;
            }
            return (paramValue == patternParamValue);
        }

        private static List<Sue> ParseSues(string[] lines)
        {
            var regex = new Regex(@"^Sue (?<number>\d+): (?:(?<param>\w+): (?<value>\d+)(?:, )?)+");
            var sues = new List<Sue>();
            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var number = int.Parse(match.Groups["number"].Value);
                var paramCaptures = match.Groups["param"].Captures;
                var valueCaptures = match.Groups["value"].Captures;
                var sue = new Sue(number);
                for (int i = 0; i < paramCaptures.Count; i++)
                {
                    var paramName = paramCaptures[i].Value;
                    var paramValue = int.Parse(valueCaptures[i].Value);
                    sue.Params.Add(paramName, paramValue);
                }
                sues.Add(sue);
            }
            return sues;
        }
    }
}