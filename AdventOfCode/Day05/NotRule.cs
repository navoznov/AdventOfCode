namespace Day05
{
    internal class NotRule : IRule
    {
        private readonly IRule _rule;

        public NotRule(IRule rule)
        {
            _rule = rule;
        }

        public bool Check(string str)
        {
            return !_rule.Check(str);
        }
    }
}