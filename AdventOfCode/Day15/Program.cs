using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Day15
{
    internal class Program
    {
        private const int TotalTeaspoonsCount = 100;
        private static void Main(string[] args)
        {
            var lines = File.ReadAllLines("input.txt");
            var ingredients = ParseIngredients(lines);

            Part1(ingredients);
            Part2(ingredients);
        }

        private static void Part1(List<Ingredient> ingredients)
        {
            var allIngredients = new Stack<Ingredient>(ingredients);

            var maxScore = GetMaxScore(allIngredients, new Cookie());

            Console.WriteLine(maxScore);
        }
        private static void Part2(List<Ingredient> ingredients)
        {
            var allIngredients = new Stack<Ingredient>(ingredients);

            const int caloriesCount = 500;
            var maxScore = GetMaxScore(allIngredients, new ExactCaloriesCookie(caloriesCount));

            Console.WriteLine(maxScore);
        }

        private static int GetMaxScore(Stack<Ingredient> freeIngredients, Cookie cookie)
        {
            if (freeIngredients.Count==0)
            {
                return cookie.GetScore();
            }

            var ingredientToAdd = freeIngredients.Pop();
            var teaspoonsCount = cookie.TeaspoonsCount;
            var maxScore = 0;
            for (int i = 0; i <= TotalTeaspoonsCount-teaspoonsCount; i++)
            {
                cookie.AddIngredientDose(ingredientToAdd, i);
                var score = GetMaxScore(freeIngredients, cookie);
                if (score>maxScore)
                {
                    maxScore = score;
                }
                cookie.RemoveIngredient(ingredientToAdd);
            }
            freeIngredients.Push(ingredientToAdd);

            return maxScore;
        }

        private static List<Ingredient> ParseIngredients(string[] lines)
        {
            var regex = new Regex(@"^(\w+): .+ (\-?\d+), .+ (\-?\d+), .+ (\-?\d+), .+ (\-?\d+), .+ (\-?\d+)");
            var ingredients = new List<Ingredient>();
            foreach (var line in lines)
            {
                var match = regex.Match(line);
                var groups = match.Groups;
                var name = groups[1].Value;
                var capacity = int.Parse(groups[2].Value);
                var durability = int.Parse(groups[3].Value);
                var flavor = int.Parse(groups[4].Value);
                var texture = int.Parse(groups[5].Value);
                var calories = int.Parse(groups[6].Value);
                var ingredient = new Ingredient(name, capacity, durability, flavor, texture, calories);
                ingredients.Add(ingredient);
            }
            return ingredients;
        }
    }
}