using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day09
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var map = ParseMap();

            Part1(map);
            Part2(map);
        }

        private static Map ParseMap()
        {
            var map = new Map();
            var lines = File.ReadAllLines("input.txt");

            foreach (var line in lines)
            {
                string city1Name;
                string city2Name;
                int distance;
                ParseLine(line, out city1Name, out city2Name, out distance);


                var city1 = map.GetByName(city1Name);
                if (city1 == null)
                {
                    city1 = new City(city1Name);
                    map.Cities.Add(city1);
                }
                var city2 = map.GetByName(city2Name);
                if (city2 == null)
                {
                    city2 = new City(city2Name);
                    map.Cities.Add(city2);
                }
                city1.Roads.Add(new RoadTo(city2, distance));
                city2.Roads.Add(new RoadTo(city1, distance));
            }
            return map;
        }

        private static void ParseLine(string line, out string city1Name, out string city2Name, out int distance)
        {
            var regex = new Regex(@"(\w+) to (\w+) = (\d+)");
            var matches = regex.Matches(line);
            city1Name = matches[0].Groups[1].Value;
            city2Name = matches[0].Groups[2].Value;
            distance = int.Parse(matches[0].Groups[3].Value);
        }

        private static void Part1(Map map)
        {
            var minDistance = GetMinDistance(map, null, new Stack<City>());

            Console.WriteLine(minDistance);
        }

        private static void Part2(Map map)
        {
            var maxDistance = GetMaxDistance(map, null, new Stack<City>());
            Console.WriteLine(maxDistance);
        }

        private static int GetMinDistance(Map map, City currentCity, Stack<City> visited)
        {
            int? minDistance = null;

            var currentDistance = 0;
            if (currentCity != null && visited.Any())
            {
                currentDistance = visited.Peek().Roads.Single(x => x.City.Name == currentCity.Name).Distance;
            }

            var unvisited = map.Cities.Except(visited).Where(x => !Equals(x, currentCity));
            if (currentCity != null)
            {
                visited.Push(currentCity);
                unvisited = unvisited.Intersect(currentCity.Roads.Select(x => x.City));
            }
            foreach (var city in unvisited)
            {
                int distance = GetMinDistance(map, city, visited);
                if (minDistance == null || distance < minDistance)
                {
                    minDistance = distance;
                }
            }
            if (currentCity != null)
            {
                visited.Pop();
            }
            currentDistance += minDistance ?? 0;
            return currentDistance;
        }

        private static int GetMaxDistance(Map map, City currentCity, Stack<City> visited)
        {
            int? maxDistance = null;

            var currentDistance = 0;
            if (currentCity != null && visited.Any())
            {
                currentDistance = visited.Peek().Roads.Single(x => x.City.Name == currentCity.Name).Distance;
            }

            var unvisited = map.Cities.Except(visited).Where(x => !Equals(x, currentCity));
            if (currentCity != null)
            {
                visited.Push(currentCity);
                unvisited = unvisited.Intersect(currentCity.Roads.Select(x => x.City));
            }
            foreach (var city in unvisited)
            {
                int distance = GetMaxDistance(map, city, visited);
                if (maxDistance == null || distance > maxDistance)
                {
                    maxDistance = distance;
                }
            }
            if (currentCity != null)
            {
                visited.Pop();
            }
            currentDistance += maxDistance ?? 0;
            return currentDistance;
        }
    }
}