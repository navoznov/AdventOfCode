using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Day21.Items;

namespace Day21
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
            var shop = new ItemsShop();
            var weapons = shop.Weapons;
            var armors = shop.Armors;
            var rings = shop.Rings;

            armors.Add(Item.CreateEmpty(ItemType.Armor));
            rings.Add(Item.CreateEmpty(ItemType.Ring));
            rings.Add(Item.CreateEmpty(ItemType.Ring));

            const int myHitpoints = 100;
            int enemyHitpoints;
            int enemyDamage;
            int enemyArmor;
            ParseEnemy(out enemyHitpoints, out enemyDamage, out enemyArmor);

            var minMoneyToWin = int.MaxValue;


            for (var r1 = 0; r1 < rings.Count; r1++)
            {
                for (var r2 = 0; r2 < r1; r2++)
                {
                    foreach (var weapon in weapons)
                    {
                        foreach (var armor in armors)
                        {
                            var items = new List<Item> {weapon, armor, shop.Rings[r1], shop.Rings[r2]};

                            var myDamage = items.Sum(x => x.Damage);
                            var myArmor = items.Sum(x => x.Armor);
                            var me = new Character(myHitpoints, myDamage, myArmor);
                            var enemy = new Character(enemyHitpoints, enemyDamage, enemyArmor);

                            if (Battle(me, enemy))
                            {
                                var cost = items.Sum(x => x.Price);
                                if (cost < minMoneyToWin)
                                {
                                    minMoneyToWin = cost;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(minMoneyToWin);
        }

        private static void Part2()
        {
            var shop = new ItemsShop();
            var weapons = shop.Weapons;
            var armors = shop.Armors;
            var rings = shop.Rings;

            armors.Add(Item.CreateEmpty(ItemType.Armor));
            rings.Add(Item.CreateEmpty(ItemType.Ring));
            rings.Add(Item.CreateEmpty(ItemType.Ring));

            int enemyHitpoints;
            int enemyDamage;
            int enemyArmor;
            ParseEnemy(out enemyHitpoints, out enemyDamage, out enemyArmor);

            const int myHitpoints = 100;
            var maxCost = 0;


            for (int r1 = 0; r1 < rings.Count; r1++)
            {
                for (int r2 = 0; r2 < r1; r2++)
                {
                    foreach (var weapon in weapons)
                    {
                        foreach (var armor in armors)
                        {
                            var items = new List<Item> {weapon, armor, rings[r1], rings[r2]};

                            var myDamage = items.Sum(x => x.Damage);
                            var myArmor = items.Sum(x => x.Armor);
                            var me = new Character(myHitpoints, myDamage, myArmor);
                            var enemy = new Character(enemyHitpoints, enemyDamage, enemyArmor);

                            if (!Battle(me, enemy))
                            {
                                var cost = items.Sum(x => x.Price);
                                if (cost > maxCost)
                                {
                                    maxCost = cost;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(maxCost);
        }

        private static bool Battle(Character me, Character enemy)
        {
            var myRoundsToDeath = (me.Hitpoints - 1)/Math.Max(enemy.Damage - me.Armor, 1);
            var enemyRoundsToDeath = (enemy.Hitpoints - 1)/Math.Max(me.Damage - enemy.Armor, 1);
            return myRoundsToDeath >= enemyRoundsToDeath;
        }

        private static void ParseEnemy(out int hitpoints, out int damage, out int armor)
        {
            var lines = File.ReadAllLines("input.txt");
            var regex = new Regex(@"[\w ]+: (?<value>\d+)");
            hitpoints = int.Parse(regex.Match(lines[0]).Groups["value"].Value);
            damage = int.Parse(regex.Match(lines[1]).Groups["value"].Value);
            armor = int.Parse(regex.Match(lines[2]).Groups["value"].Value);
        }
    }
}