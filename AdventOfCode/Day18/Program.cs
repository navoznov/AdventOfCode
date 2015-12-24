using System;
using System.IO;
using System.Linq;

namespace Day18
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
            const int stepsCount = 100;

            Func<int, LightsMatrix> creator = size => new LightsMatrix(size);
            var matrix = ParseLightsMatrix(lines, creator);
            matrix = AnimateMatrix(stepsCount, matrix);
            Console.WriteLine(matrix.GetTurnedOnLightsCount());
        }

        private static void Part2()
        {
            var lines = File.ReadAllLines("input.txt");
            const int stepsCount = 100;

            Func<int, LightsMatrix> creator = size => new WrongLightsMatrix(size);
            var matrix = ParseLightsMatrix(lines, creator);
            matrix = AnimateMatrix(stepsCount, matrix);
            Console.WriteLine(matrix.GetTurnedOnLightsCount());
        }

        private static LightsMatrix AnimateMatrix(int stepsCount, LightsMatrix matrix)
        {
            for (var currentStep = 0; currentStep < stepsCount; currentStep++)
            {
                matrix = GetNextStepLightsMatrix(matrix);
            }
            return matrix;
        }

        private static LightsMatrix ParseLightsMatrix(string[] lines, Func<int, LightsMatrix> creator)
        {
            int lightsMatrixSize = lines.Length;
            var matrix = creator(lightsMatrixSize);
            for (var i = 0; i < lightsMatrixSize; i++)
            {
                var line = lines[i];
                for (var j = 0; j < lightsMatrixSize; j++)
                {
                    matrix[j, i] = line[j] == '#';
                }
            }
            return matrix;
        }

        private static LightsMatrix GetNextStepLightsMatrix(LightsMatrix matrix)
        {
            var newMatrix = matrix.New();

            for (int x = 0; x < matrix.Size; x++)
            {
                for (int y = 0; y < matrix.Size; y++)
                {
                    newMatrix[x, y] = matrix.GetNextLightState(x, y);
                }
            }

            return newMatrix;
        }
    }
}