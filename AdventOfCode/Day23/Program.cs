using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Day23.Instructions;

namespace Day23
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            Part1(lines);
            Part2(lines);
        }

        private static void Part1(string[] lines)
        {
            var aRegister = new Register("a");
            var bRegister = new Register("b");
            var instructionFactory = new InstructionFactory(new[] {aRegister, bRegister,});
            var instructions = instructionFactory.Parse(lines).ToList();
            var program = new Computer(instructions);
            program.Execute();

            Console.WriteLine(bRegister.Value);
        }

        private static void Part2(string[] lines)
        {
            var aRegister = new Register("a") {Value = 1};
            var bRegister = new Register("b");
            var instructionFactory = new InstructionFactory(new[] {aRegister, bRegister,});
            var instructions = instructionFactory.Parse(lines).ToList();
            var program = new Computer(instructions);
            program.Execute();

            Console.WriteLine(bRegister.Value);
        }
    }
}