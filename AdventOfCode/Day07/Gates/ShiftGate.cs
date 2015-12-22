namespace Day07.Gates
{
    internal abstract class ShiftGate : IHasValue
    {
        protected readonly IHasValue _source;
        protected readonly ushort _bitsNumber;

        protected ShiftGate(IHasValue source, ushort bitsNumber)
        {
            _source = source;
            _bitsNumber = bitsNumber;
        }

        public abstract ushort GetValue();
    }
}