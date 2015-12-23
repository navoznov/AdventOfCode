using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day11
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
            var newPassword = GetNextPassword(input);
            Console.WriteLine(newPassword);
        }
        private static void Part2()
        {
            var input = File.ReadAllText("input.txt");
            // twice
            var newPassword = GetNextPassword(GetNextPassword(input));
            Console.WriteLine(newPassword);
        }

        private static string GetNextPassword(string password)
        {
            var newPassword = password;
            var rules = new List<IRule>
            {
                new HasTwoLettersPairsRule(),
                new NotContainsLettersRule(),
                new HasIncreasingStraightRule()
            };

            do
            {
                newPassword = Increment(newPassword);
            } while (rules.Any(x => !x.Check(newPassword)));
            return newPassword;
        }

        static string Increment(string str)
        {
            var chars = str.ToCharArray();
            var index = chars.Length - 1;
                chars[index]++;
            while (chars[index]>'z')
            {
                chars[index] = 'a';
                index--;
                chars[index]++;
            }
            return new string(chars);
        }
    }
}