using System.Diagnostics;

namespace Day07
{
    [DebuggerDisplay("ConstantValue: Value = {_value}")]
    internal class ConstantValue : IHasValue
    {
        private readonly ushort _value;

        public ConstantValue(ushort value)
        {
            _value = value;
        }

        public ushort GetValue()
        {
            return _value;
        }

        public static bool TryParse(string str, out ConstantValue constantValue)
        {
            ushort value;
            constantValue = ushort.TryParse(str, out value) ? new ConstantValue(value) : null;
            return constantValue != null;
        }
    }
}