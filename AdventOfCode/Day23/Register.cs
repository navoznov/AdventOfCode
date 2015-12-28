namespace Day23
{
    internal class Register
    {
        public string Name { get; private set; }
        public int Value { get; set; }

        public Register(string name)
        {
            Name = name;
            Value = 0;
        }
    }
}