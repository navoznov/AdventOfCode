using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day08
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
            var lines = File.ReadAllLines("input.txt");
            var originalTextLettersCounter = 0;
            var modifiedTextLettersCounter = 0;
            foreach (var line in lines)
            {
                originalTextLettersCounter += line.Length;
                var modifiedLine = line.Substring(1, line.Length - 2).Replace(@"\""", "\"").Replace(@"\\", @"\");
                modifiedLine = Regex.Replace(modifiedLine, @"\\x[0-9a-f]{2}", "?");
                modifiedTextLettersCounter += modifiedLine.Length;
            }

            Console.WriteLine(originalTextLettersCounter - modifiedTextLettersCounter);
        }

        private static void Part2()
        {
            var lines = File.ReadAllLines("input.txt");
            var originalTextLettersCounter = 0;
            var modifiedTextLettersCounter = 0;
            foreach (var line in lines)
            {
                originalTextLettersCounter += line.Length;
                var modifiedLine = line.Replace(@"\", @"\\").Replace(@"""", @"\""");

                modifiedLine = @"""" + modifiedLine + @"""";
                Console.WriteLine(line);
                Console.WriteLine(modifiedLine);
                Console.WriteLine();
                modifiedTextLettersCounter += modifiedLine.Length;
            }

            Console.WriteLine(modifiedTextLettersCounter - originalTextLettersCounter);
        }
    }
}