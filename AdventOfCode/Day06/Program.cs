using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day06
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
            var lines = File.ReadAllLines("input1.txt");
            var map = new LightsMap<bool>(1000, 1000);

            foreach (var line in lines)
            {
                Commands command;
                Range range;
                ParseCommand(line, out command, out range);

                for (int i = range.From.X; i <= range.To.X; i++)
                {
                    for (int j = range.From.Y; j <= range.To.Y; j++)
                    {
                        switch (command)
                        {
                            case Commands.TurnOff:
                                map[i, j] = false;

                                break;
                            case Commands.TurnOn:
                                map[i, j] = true;
                                break;
                            case Commands.Toggle:
                                map[i, j] = !map[i, j];
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }

            var result = 0;
            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    if (map[i, j])
                    {
                        result++;
                    }
                }
            }

            Console.WriteLine(result);
        }

        private static void Part2()
        {
            var lines = File.ReadAllLines("input2.txt");
            var map = new LightsMap<int>(1000, 1000);

            foreach (var line in lines)
            {
                Commands command;
                Range range;
                ParseCommand(line, out command, out range);

                for (int i = range.From.X; i <= range.To.X; i++)
                {
                    for (int j = range.From.Y; j <= range.To.Y; j++)
                    {
                        switch (command)
                        {
                            case Commands.TurnOff:
                                if (map[i, j] > 0)
                                {
                                    map[i, j] = map[i, j] - 1;
                                }
                                break;
                            case Commands.TurnOn:
                                map[i, j] = map[i, j] + 1;
                                break;
                            case Commands.Toggle:
                                map[i, j] = map[i, j] + 2;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }
                }
            }

            var result = 0;
            for (int i = 0; i < map.Width; i++)
            {
                for (int j = 0; j < map.Height; j++)
                {
                    result += map[i, j];
                }
            }

            Console.WriteLine(result);
        }

        private static void ParseCommand(string str, out Commands command, out Range range)
        {
            const string turnOffStr = "turn off";
            const string turnOnStr = "turn on";
            const string toggleStr = "toggle";
            if (str.StartsWith(turnOffStr))
            {
                command = Commands.TurnOff;
            }
            else if (str.StartsWith(turnOnStr))
            {
                command = Commands.TurnOn;
            }
            else if (str.StartsWith(toggleStr))
            {
                command = Commands.Toggle;
            }
            else
            {
                throw new ArgumentException("unknown command");
            }

            var regex = new Regex(@"(\d+)\,(\d+)");
            var matches = regex.Matches(str);
            var x1 = int.Parse(matches[0].Groups[1].Value);
            var y1 = int.Parse(matches[0].Groups[2].Value);
            var x2 = int.Parse(matches[1].Groups[1].Value);
            var y2 = int.Parse(matches[1].Groups[2].Value);
            range = new Range(new Point(x1, y1), new Point(x2, y2));
        }
    }
}