namespace Day07.Gates
{
    internal abstract class UnaryLogicGate : IHasValue
    {
        private readonly IHasValue _source;

        public UnaryLogicGate(IHasValue source)
        {
            _source = source;
        }

        public IHasValue Source
        {
            get { return _source; }
        }

        public abstract ushort GetValue();
    }
}