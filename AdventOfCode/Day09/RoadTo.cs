using System.Diagnostics;

namespace Day09
{
    [DebuggerDisplay("{Distance} to {City.Name}")]
    internal class RoadTo
    {
        public int Distance { get; set; }

        public City City { get; set; }

        public RoadTo(City city, int distance)
        {
            Distance = distance;
            City = city;
        }
    }
}