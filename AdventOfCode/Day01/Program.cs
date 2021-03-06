﻿using System;
using System.IO;

namespace Day01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Part1();
            Console.WriteLine();
            Part2();
        }

        private static void Part1()
        {
            Console.WriteLine("Part 1");
            var input = File.ReadAllText("input1.txt");
            var resultFloor = 0;
            for (int i = 0; i < input.Length; i++)
            {
                var currentParenthesis = input[i];
                if (currentParenthesis == '(')
                    resultFloor++;
                else if (currentParenthesis == ')')
                {
                    resultFloor--;
                }
            }
            Console.WriteLine(resultFloor);
        }

        private static void Part2()
        {
            Console.WriteLine("Part 2");
            var input = File.ReadAllText("input2.txt");

            var currentFloor = 0;
            var result = -1;
            for (int i = 0; i < input.Length; i++)
            {
                var currentParenthesis = input[i];
                if (currentParenthesis == '(')
                    currentFloor++;
                else if (currentParenthesis == ')')
                {
                    currentFloor--;
                }
                if (currentFloor == -1)
                {
                    result = i + 1;
                    break;
                }
            }
            Console.WriteLine(result);
        }
    }
}