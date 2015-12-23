using System.Collections.Generic;
using System.Diagnostics;

namespace Day09
{
    [DebuggerDisplay("City - {Name}")]
    internal class City
    {
        public string Name { get; set; }
        public List<RoadTo> Roads { get; set; }

        public City(string name)
        {
            Name = name;
            Roads = new List<RoadTo>();
        }

        protected bool Equals(City other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((City)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }
    }
}