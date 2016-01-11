using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;

namespace Day12
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
            var input = File.ReadAllText("input.txt");
            var sum = GetSumOfInts(input);
            Console.WriteLine(sum);
        }

        private static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            var jObject = JObject.Parse(input);

            var sum = GetSumOfNonRedInts(jObject);
            Console.WriteLine(sum);
        }

        private static int GetSumOfInts(string input)
        {
            var regex = new Regex(@"(-?\d+)");
            var matches = regex.Matches(input).OfType<Match>().ToList();
            var sum = matches.Sum(x => int.Parse(x.Value));
            return sum;
        }

        private static long GetSumOfNonRedInts(JToken jToken)
        {
            var jObject = jToken as JObject;
            if (jObject != null)
            {
                return !HasRed(jObject) ? jObject.Properties().Select(x => x.Value).Sum(x => GetSumOfNonRedInts(x)) : 0;
            }
            var jArray = jToken as JArray;
            if (jArray != null)
            {
                return jArray.Sum(x => GetSumOfNonRedInts(x));
            }
            var jValue = jToken as JValue;
            if (jValue != null)
            {
                var value = jValue.Value;
                return value as long? ?? 0;
            }
            throw new InvalidOperationException();
        }

        private static bool HasRed(JObject jObject)
        {
            return jObject.Properties()
                .Select(x => x.Value)
                .OfType<JValue>()
                .Any(x => x.Value<string>() == "red");
        }
    }
}