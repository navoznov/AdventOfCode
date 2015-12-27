using System.Diagnostics;

namespace Day22
{
    [DebuggerDisplay("{Name}")]
    internal class Spell
    {
        public string Name { get; set; }
        public int ManaCost { get; set; }
        public int Duration { get; set; }
        public int ManaCharge { get; set; }
        public int Damage { get; set; }
        public int Heal { get; set; }
        public int Armor { get; set; }

        public Spell(string name, int manaCost, int duration = 0, int manaCharge = 0, int damage = 0, int heal = 0,
            int armor = 0)
        {
            Name = name;
            ManaCost = manaCost;
            Duration = duration;
            ManaCharge = manaCharge;
            Damage = damage;
            Heal = heal;
            Armor = armor;
        }
    }
}