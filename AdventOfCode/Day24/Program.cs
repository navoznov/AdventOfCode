using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day24
{
    internal class Program
    {
        private static int _minGroupCount;

        private static void Main(string[] args)
        {
            var packages = File.ReadAllLines("input.txt").Select(long.Parse).ToList();
            Part1(packages);
            Part2(packages);
        }

        private static void Part1(List<long> packages)
        {
            const int groupsCount = 3;
            var totalWeight = packages.Sum();
            var groupWeight = totalWeight/groupsCount;
            _minGroupCount = packages.Count/groupsCount + 1;

            GetIdealConfigurationQuantum(groupWeight, packages);
        }

        private static void Part2(List<long> packages)
        {
            const int groupsCount = 4;
            var totalWeight = packages.Sum();
            var groupWeight = totalWeight/groupsCount;
            _minGroupCount = packages.Count/groupsCount + 1;

            GetIdealConfigurationQuantum(groupWeight, packages);
        }

        private static void GetIdealConfigurationQuantum(long groupWeight, List<long> packages)
        {
            var allCombs = GetCombs(groupWeight, new List<long>(), packages).ToList();
            var combs = allCombs
                .Select(x => new {Quantum = GetQuantumEntanglement(x), x.Count})
                .OrderBy(x => x.Count)
                .ThenBy(x => x.Quantum);
            Console.WriteLine(combs.First().Quantum);
        }

        private static long GetQuantumEntanglement(IEnumerable<long> @group)
        {
            return @group.Aggregate((x, y) => x*y);
        }

        public static IEnumerable<List<long>> GetCombs(long groupWeight, List<long> used, List<long> free)
        {
            if (used.Count >= _minGroupCount)
            {
                yield break;
            }

            var remainingWeight = groupWeight - used.Sum();

            for (var i = 0; i < free.Count; i++)
            {
                var current = free[i];
                if (current > remainingWeight)
                {
                    continue;
                }
                var currentUsed = used.ToList();
                currentUsed.Add(current);
                if (current == remainingWeight)
                {
                    if (currentUsed.Count < _minGroupCount)
                    {
                        _minGroupCount = currentUsed.Count;
                    }
                    yield return currentUsed;
                }
                else
                {
                    var currentFree = free.Skip(i + 1).ToList();
                    foreach (var comb in GetCombs(groupWeight, currentUsed, currentFree))
                    {
                        yield return comb;
                    }
                }
            }
        }
    }
}