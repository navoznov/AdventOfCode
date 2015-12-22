using System;
using System.IO;
using System.Linq;

namespace Day02
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();

        }

        private static void Part2()
        {
            var input = File.ReadAllLines("input2.txt");

            var result = 0;

            foreach (var line in input)
            {
                int l;
                int w;
                int h;
                ParseDimensions(line, out l, out w, out h);

                var lwHalfPerimeter = l + w;
                var whHalfPerimeter = w + h;
                var lhHalfPerimeter = l + h;
                var minHalfPerimeters = new[] { lwHalfPerimeter, whHalfPerimeter, lhHalfPerimeter }.Min();
                result += 2* minHalfPerimeters + l*w*h;
            }

            Console.WriteLine(result);
        }
        private static void Part1()
        {
            var input = File.ReadAllLines("input1.txt");

            var result = 0;

            foreach (var line in input)
            {
                int l;
                int w;
                int h;
                ParseDimensions(line, out l, out w, out h);

                var lwArea = l*w;
                var whArea = w*h;
                var lhArea = l*h;
                var boxSidesArea = 2*(lwArea + whArea + lhArea);
                var minArea = new[] {lwArea, whArea, lhArea}.Min();
                result += boxSidesArea + minArea;
            }

            Console.WriteLine(result);
        }

        private static void ParseDimensions(string line, out int l, out int w, out int h)
        {
            var dimensionsStr = line.Split('x');

            l = int.Parse(dimensionsStr[0]);
            w = int.Parse(dimensionsStr[1]);
            h = int.Parse(dimensionsStr[2]);
        }
    }
}
