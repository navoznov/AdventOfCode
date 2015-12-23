using System.Collections.Generic;
using System.Linq;

namespace Day09
{
    internal class Map
    {
        public List<City> Cities { get; set; }

        public Map()
        {
            Cities = new List<City>();
        }

        public City GetByName(string name)
        {
            return Cities.SingleOrDefault(city => city.Name == name);
        }
    }
}