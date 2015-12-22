using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            Part1();
            Part2();
        }

        private static void Part1()
        {
            var input = File.ReadAllText("input1.txt");
            var currentSantaLocation = new Point(0, 0);
            var deliveredHouses = new List<Point> {currentSantaLocation};

            for (int i = 0; i < input.Length; i++)
            {
                var directionChar = input[i];
                var direction = DirectionVector.ParseDirection(directionChar);
                currentSantaLocation = currentSantaLocation + direction;
                deliveredHouses.Add(currentSantaLocation);
            }

            var distinctHouses = deliveredHouses.Distinct().ToList();
            Console.WriteLine(distinctHouses.Count);
        }

        private static void Part2()
        {
            var input = File.ReadAllText("input2.txt");
            var startPoint = new Point(0, 0);
            var currentSantaLocation = startPoint;
            var currentRoboLocation = startPoint;
            var currentDeliverersLocations = new[] {currentSantaLocation, currentRoboLocation};
            var deliveredHouses = new List<Point> {currentSantaLocation};

            var deliverersCount = currentDeliverersLocations.Length;
            for (int i = 0; i < input.Length; i=i+deliverersCount)
            {
                for (int j = 0; j < deliverersCount; j++)
                {
                    var directionChar = input[i+j];
                    var direction = DirectionVector.ParseDirection(directionChar);
                    currentDeliverersLocations[j] = currentDeliverersLocations[j] + direction;
                    deliveredHouses.Add(currentDeliverersLocations[j]);
                }
            }

            var distinctHouses = deliveredHouses.Distinct().ToList();
            Console.WriteLine(distinctHouses.Count);
        }
    }
}
