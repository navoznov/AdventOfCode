using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Part1();
            //Part2();  - недоделано
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

            var totalSum = GetSumOfInts(input);

            int pos = 0;
            var redSum = 0;
            do
            {
                pos = input.IndexOf("red", pos + 1);
                if (pos < 0)
                {
                    break;
                }
                int openBracePos;
                if (!TryGetOpenBracePos(pos, input, out openBracePos))
                {
                    continue;
                }
                int closeBracePos;
                if (!TryGetCloseBracePos(pos, input, out closeBracePos))
                {
                    continue;
                }

                var redBlockStr = input.Substring(openBracePos + 1, closeBracePos - openBracePos - 1);
                redSum += GetSumOfInts(redBlockStr);
                input = input.Substring(0, openBracePos) + input.Substring(closeBracePos + 1);
            } while (true);

            //var regex = new Regex(@"[\{][^\{]*?red[^\{]*?[\}]");
            //var matches = regex.Matches(input).OfType<Match>().ToList();
            //foreach (var match in matches)
            //{
            //    var currentRedSum = GetSumOfInts(match.Value);
            //    redSum += currentRedSum;
            //}
            Console.WriteLine(totalSum - redSum);
        }

        private static bool TryGetOpenBracePos(int pos, string input, out int openBracePos)
        {
            openBracePos = -1;
            var closeBraceCounter = 0;
            for (int i = pos - 1; i >= 0; i--)
            {
                var currentChar = input[i];
                if (currentChar == '[' && closeBraceCounter == 0)
                {
                    return false;
                }
                if (currentChar == '{')
                {
                    if (closeBraceCounter != 0)
                    {
                        closeBraceCounter--;
                    }
                    else
                    {
                        openBracePos = i;
                        break;
                    }
                }
                if (currentChar == '}')
                {
                    closeBraceCounter++;
                }
            }
            return openBracePos > -1;
        }

        private static bool TryGetCloseBracePos(int pos, string input, out int closeBracePos)
        {
            // {"d":"red","e":[1,2,3,4],"f":5}  - 0
            // [1,{"c":"red","b":2},3]          - 4
            // [1,"red",{"x":1},5]              - 7
            closeBracePos = -1;
            var openBraceCounter = 0;
            var openArrayBraceCounter = 0;

            for (var i = pos; i < input.Length; i++)
            {
                var c = input[i];

                // todo:
            }
            return closeBracePos > -1;
        }

        private static int GetSumOfInts(string input)
        {
            var regex = new Regex(@"(-?\d+)");
            var matches = regex.Matches(input).OfType<Match>().ToList();
            var sum = matches.Sum(x => int.Parse(x.Value));
            return sum;
        }
    }
}