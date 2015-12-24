using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day17
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
            var sizes = File.ReadAllLines("input.txt").Select(int.Parse).ToList();
            const int totalVolume = 150;
            var combinations = GetCombinations(new List<int>(), sizes, totalVolume).ToList();
            Console.WriteLine(combinations.Count);
        }

        private static void Part2()
        {
            var sizes = File.ReadAllLines("input.txt").Select(int.Parse).ToList();
            const int totalVolume = 150;
            var combinations = GetCombinations(new List<int>(), sizes, totalVolume).ToList();
            var minCount = combinations.Min(x => x.Count);
            var shortestCombinationsCount = combinations.Count(x => x.Count == minCount);
            Console.WriteLine(shortestCombinationsCount);
        }

        private static IEnumerable<List<int>> GetCombinations(List<int> usedSizes, List<int> freeSizes, int totalVolume)
        {
            var usedSizesSum = usedSizes.Sum(x => x);
            if (usedSizesSum == totalVolume)
            {
                yield return usedSizes;
            }
            for (int i = 0; i < freeSizes.Count; i++)
            {
                var currentSize = freeSizes[i];
                if (currentSize + usedSizesSum > totalVolume)
                {
                    continue;
                }

                var currentUsedSizes = usedSizes.ToList();
                currentUsedSizes.Add(currentSize);
                if (currentSize + usedSizesSum == totalVolume)
                {
                    yield return currentUsedSizes;
                    continue;
                }
                var currentFreeSizes = freeSizes.Skip(i + 1).ToList();
                var combinations = GetCombinations(currentUsedSizes, currentFreeSizes, totalVolume);
                foreach (var combination in combinations)
                {
                    yield return combination;
                }
            }
        }
    }
}