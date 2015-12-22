namespace Day07.Gates
{
    internal abstract class BinaryLogicGate : IHasValue
    {
        private readonly IHasValue _source1;
        private readonly IHasValue _source2;

        protected BinaryLogicGate(IHasValue source1, IHasValue source2)
        {
            _source1 = source1;
            _source2 = source2;
        }

        public IHasValue Source1
        {
            get { return _source1; }
        }

        public IHasValue Source2
        {
            get { return _source2; }
        }

        public abstract ushort GetValue();
    }
}