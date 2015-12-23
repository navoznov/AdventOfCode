using System.Collections.Generic;

namespace Day15
{
    internal class Ingredient
    {
        public readonly string Name;
        public readonly int Capacity;
        public readonly int Durability;
        public readonly int Flavor;
        public readonly int Texture;
        public readonly int Calories;

        public Ingredient(string name, int capacity, int durability, int flavor, int texture, int calories)
        {
            Name        = name;
            Capacity    = capacity;
            Durability  = durability;
            Flavor      = flavor;
            Texture     = texture;
            Calories    = calories;
        }

        private sealed class NameEqualityComparer : IEqualityComparer<Ingredient>
        {
            public bool Equals(Ingredient x, Ingredient y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Ingredient obj)
            {
                return (obj.Name != null ? obj.Name.GetHashCode() : 0);
            }
        }

        private static readonly IEqualityComparer<Ingredient> NameComparerInstance = new NameEqualityComparer();

        public static IEqualityComparer<Ingredient> NameComparer
        {
            get { return NameComparerInstance; }
        }
    }
}