using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Day25
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");
            int row;
            int col;
            ParseInput(input, out row, out col);

            const ulong firstCode = 20151125;
            var code = GetCode(row, col, firstCode);
            Console.WriteLine(code);
        }

        private static void ParseInput(string input, out int row, out int col)
        {
            var regex = new Regex(@"row (?<row>\d+).+column (?<col>\d+)");
            var match = regex.Match(input);
            row = int.Parse(match.Groups["row"].Value);
            col = int.Parse(match.Groups["col"].Value);
        }

        private static ulong GetNextCode(ulong current)
        {
            return (current*252533)%33554393;
        }

        private static ulong GetCode(int row, int col, ulong firstCode)
        {
            var currentRow = 1;
            var currentCol = 1;
            var currentCode = firstCode;
            while (currentRow != row || currentCol != col)
            {
                currentCode = GetNextCode(currentCode);
                if (currentRow == 1)
                {
                    currentRow = currentCol + 1;
                    currentCol = 1;
                }
                else
                {
                    currentRow--;
                    currentCol++;
                }
            }
            return currentCode;
        }
    }
}