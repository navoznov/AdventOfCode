using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day14
{
    class Program
    {
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var reindeers = ParseReindeers(lines);

            Part1(reindeers);
            Part2(reindeers);
        }

        private static void Part1(List<Reindeer> reindeers)
        {
            const int totalTime = 2503;
            var maxDistance = reindeers.Max(x => x.GetDistanceByTime(totalTime));
            Console.WriteLine(maxDistance);
        }

        private static void Part2(List<Reindeer> reindeers)
        {
            var racingInfos = reindeers.Select(x => new ReindeerRacingInfo(x)).ToList();

            const int totalTime = 2503;
            for (int i = 1; i <= totalTime; i++)
            {
                foreach (var racingInfo in racingInfos)
                {
                    racingInfo.CurrentDistance = racingInfo.Reindeer.GetDistanceByTime(i);
                }

                var maxDistance = racingInfos.Max(x => x.CurrentDistance);
                racingInfos.Where(x => x.CurrentDistance >= maxDistance).ToList().ForEach(x => x.BonusValue++);
            }
            var maxTotalDistance = racingInfos.Max(x => x.BonusValue);
            Console.WriteLine(maxTotalDistance);
        }

        private static List<Reindeer> ParseReindeers(string[] lines)
        {
            var regex = new Regex(@"^(\w+) .+ (\d+) .+ for (\d+) .+ (\d+) .+");
            var reindeers = new List<Reindeer>();
            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var groups = match.Groups;
                var name = groups[1].Value;
                var speed = int.Parse(groups[2].Value);
                var speedTime = int.Parse(groups[3].Value);
                var restTime = int.Parse(groups[4].Value);
                var reindeer = new Reindeer(name, speed, speedTime, restTime);
                reindeers.Add(reindeer);
            }
            return reindeers;
        }
    }
}
