using System.Collections.Generic;

namespace Day16
{
    public class Sue
    {
        public int Number { get; set; }

        public Dictionary<string, int> Params { get; set; }

        public Sue(int number)
        {
            Number = number;
            Params = new Dictionary<string, int>();
        }
    }
}