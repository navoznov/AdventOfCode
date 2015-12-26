using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Day21.Items;

namespace Day21
{
    internal class ItemsShop
    {
        public List<Item> Weapons { get; private set; }

        public List<Item> Armors { get; private set; }

        public List<Item> Rings { get; private set; }

        public ItemsShop()
        {
            Weapons = new List<Item>();
            Armors = new List<Item>();
            Rings = new List<Item>();

            var lines = File.ReadAllLines("shop.txt");

            string section = null;
            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    section = null;
                    continue;
                }
                if (section == null)
                {
                    section = ParseSectionTitle(line);
                    continue;
                }

                switch (section)
                {
                    case "Weapons":
                        Weapons.Add(ParseItem(line, ItemType.Weapon));
                        break;
                    case "Armor":
                        Armors.Add(ParseItem(line, ItemType.Armor));
                        break;
                    case "Rings":
                        Rings.Add(ParseItem(line, ItemType.Ring));
                        break;
                    default:
                        throw new InvalidDataException("Неизвестная секция в ассортименте магазина");
                }
            }
        }

        private static Item ParseItem(string line, ItemType type)
        {
            var itemRegex = new Regex(@"^(?<name>.+) +(?<price>\d+) +(?<damage>\d+) +(?<armor>\d+)");
            var match = itemRegex.Match(line);
            var name = match.Groups["name"].Value;
            var price = int.Parse(match.Groups["price"].Value);
            var damage = int.Parse(match.Groups["damage"].Value);
            var armor = int.Parse(match.Groups["armor"].Value);
            return new Item(type, name, price, damage, armor);
        }

        private static string ParseSectionTitle(string line)
        {
            var sectionNameRegex = new Regex(@"^(?<section>\w+):");
            return sectionNameRegex.Match(line).Groups["section"].Value;
        }
    }
}