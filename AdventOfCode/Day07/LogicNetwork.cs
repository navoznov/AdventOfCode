using System.Collections.Generic;
using System.Linq;

namespace Day07
{
    internal class LogicNetwork
    {
        public LogicNetwork()
        {
            Elements = new List<IHasValue>();
        }

        public List<IHasValue> Elements { get; set; }

        public Wire GetByName(string name)
        {
            return Elements.OfType<Wire>().SingleOrDefault(x => x.Name == name);
        }
    }
}