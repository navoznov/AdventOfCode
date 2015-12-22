using System.Collections.Generic;
using System.Diagnostics;

namespace Day07
{
    [DebuggerDisplay("Wire: Name = {Name}")]
    internal class Wire : IHasValue
    {
        private ushort? _value;
        private readonly string _name;
        public IHasValue Source { get; set; }

        public string Name
        {
            get { return _name; }
        }

        public Wire(string name)
        {
            _name = name;
        }

        public Wire(string name, IHasValue source) : this(name)
        {
            Source = source;
        }

        public void SetValue(ushort value)
        {
            _value = value;
        }
        public void Reset()
        {
            _value = null;
        }
        public ushort GetValue()
        {
            if (!_value.HasValue)
            {
                _value = Source.GetValue();
            }
            return _value.Value;
        }
    }
}