using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day13
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
            List<string> allPeople;
            Conditions conditions;
            ParseConditions(lines, out allPeople, out conditions);
            var atTable = new Stack<string>();
            var maxHappiness = GetMaxHappiness(atTable, allPeople, conditions);
            Console.WriteLine(maxHappiness);
        }

        private static void Part2()
        {
            var lines = File.ReadAllLines("input.txt");
            List<string> allPeople;
            Conditions conditions;
            ParseConditions(lines, out allPeople, out conditions);

            const string myName = "Me";
            foreach (var person in allPeople)
            {
                conditions.Add(new Condition(myName, person, 0));
                conditions.Add(new Condition(person, myName, 0));
            }
            allPeople.Add(myName);

            var atTable = new Stack<string>();
            var maxHappiness = GetMaxHappiness(atTable, allPeople, conditions);
            Console.WriteLine(maxHappiness);
        }


        private static int GetMaxHappiness(Stack<string> atTable, List<string> free, Conditions conditions)
        {
            if (free.Count == 1)
            {
                atTable.Push(free.Single());
                var table = new Table(atTable.ToList());
                var totalHappiness = table.CalcTotalHappiness(conditions);
                atTable.Pop();
                return totalHappiness;
            }
            var maxHappiness = 0;
            for (int i = 0; i < free.Count; i++)
            {
                atTable.Push(free[i]);
                free.RemoveAt(i);
                var happiness = GetMaxHappiness(atTable, free, conditions);
                if (happiness > maxHappiness)
                {
                    maxHappiness = happiness;
                }
                var person = atTable.Pop();
                free.Insert(i, person);
            }
            return maxHappiness;
        }

        private static void ParseConditions(string[] lines, out List<string> people, out Conditions conditions)
        {
            var regex = new Regex(@"^(\w+) .+(gain|lose) (\d+).+to (\w+)\.");
            var conditionsList = new List<Condition>();
            people = new List<string>();
            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var groups = match.Groups;
                var subjectName = groups[1].Value;
                var happinessSign = groups[2].Value == "gain" ? 1 : -1;
                var happinesUnitsCount = int.Parse(groups[3].Value);
                var objectName = groups[4].Value;
                if (!people.Contains(subjectName))
                {
                    people.Add(subjectName);
                }

                var condition = new Condition(subjectName, objectName, happinessSign*happinesUnitsCount);
                conditionsList.Add(condition);
            }
            conditions = new Conditions(conditionsList);
        }
    }
}