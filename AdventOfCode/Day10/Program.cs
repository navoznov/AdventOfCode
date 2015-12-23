using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Day10
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");

            Part1(input);
            Part2(input);
        }

        private static void Part2(string input)
        {
            GetLookAndSayText(input, 50);
        }

        private static void Part1(string input)
        {
            GetLookAndSayText(input, 40);
        }

        private static void GetLookAndSayText(string text, int itarationsCount)
        {
            var regex = new Regex(@"((\d)\2*)");
            for (var i = 0; i < itarationsCount; i++)
            {
                var matches = regex.Matches(text);
                var sb = new StringBuilder();
                for (int j = 0; j < matches.Count; j++)
                {
                    var value = matches[j].Groups[0].Value;
                    sb.Append(value.Length).Append(value[0]);
                }
                text = sb.ToString();
            }
            Console.WriteLine(text.Length);
        }
    }
}