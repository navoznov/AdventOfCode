using System;
using System.Linq;

namespace Day20
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int totalPresentsCount = 34000000;
            Part1(totalPresentsCount);
            Part2(totalPresentsCount);
        }

        private static void Part1(int totalPresentsCount)
        {
            var minHouseNumber = GetMinHouseNumber1(totalPresentsCount);
            Console.WriteLine(minHouseNumber);
        }

        private static void Part2(int totalPresentsCount)
        {
            var minHouseNumber = GetMinHouseNumber2(totalPresentsCount);
            Console.WriteLine(minHouseNumber);
        }

        private static int GetMinHouseNumber1(int totalPresentsCount)
        {
            const int presentsPerHouse = 10;
            var houseNumberCounter = 0;
            int presentsCounter;
            do
            {
                houseNumberCounter++;
                var houseNumber = houseNumberCounter;
                presentsCounter = Enumerable.Range(1, houseNumberCounter).Where(elfNumber => houseNumber%elfNumber == 0).Sum()*presentsPerHouse;
            } while (presentsCounter < totalPresentsCount);
            return houseNumberCounter;
        }

        private static int GetMinHouseNumber2(int totalPresentsCount)
        {
            const int housesPerElf = 50;
            const int presentsPerHouse = 11;
            var houseCounter = 0;
            int presentsCounter;
            do
            {
                houseCounter++;
                var houseNumber = houseCounter;
                presentsCounter = Enumerable.Range(1, houseCounter).Where(elfNumber => houseNumber % elfNumber == 0 && houseNumber/elfNumber<=housesPerElf).Sum() * presentsPerHouse;
            } while (presentsCounter < totalPresentsCount);
            return houseCounter;
        }

        private static int GetPresentsForHouse(int houseNumber, int baseElfPresentsCount)
        {
            var presentsCounter = 0;
            for (var elfNumber = 1; elfNumber <= houseNumber; elfNumber++)
            {
                if (houseNumber%elfNumber == 0)
                {
                    presentsCounter += elfNumber*baseElfPresentsCount;
                }
            }
            return presentsCounter;
        }
    }
}