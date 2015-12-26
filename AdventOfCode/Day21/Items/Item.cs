using System.Diagnostics;

namespace Day21.Items
{
    [DebuggerDisplay("{Type} - {Price} - {Damage} - {Armor}")]
    internal class Item
    {
        private readonly ItemType _type;
        private readonly string _name;
        private readonly int _price;
        private readonly int _damage;
        private readonly int _armor;

        public Item(ItemType type, string name, int price, int damage, int armor)
        {
            _type = type;
            _name = name;
            _price = price;
            _damage = damage;
            _armor = armor;
        }

        public int Price
        {
            get { return _price; }
        }


        public string Name
        {
            get { return _name; }
        }

        public int Damage
        {
            get { return _damage; }
        }

        public int Armor
        {
            get { return _armor; }
        }

        public static Item CreateEmpty(ItemType type)
        {
            return new Item(type, "Empty", 0, 0, 0);
        }

        public ItemType Type
        {
            get { return _type; }
        }
    }
}