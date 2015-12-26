namespace Day21
{
    internal class Character
    {
        private int _hitpoints;
        private readonly int _damage;
        private readonly int _armor;


        public int Hitpoints
        {
            get { return _hitpoints; }
        }

        public int Damage
        {
            get { return _damage; }
        }

        public int Armor
        {
            get { return _armor; }
        }

        public Character(int hitpoints, int damage, int armor)
        {
            _hitpoints = hitpoints;
            _damage = damage;
            _armor = armor;
        }

        public int GetDamageBy(Character character)
        {
            var damage = character.Damage - Armor;
            return damage > 0 ? damage : 1;
        }

        public void TakeDamageBy(Character character)
        {
            _hitpoints -= GetDamageBy(character);
        }
    }
}