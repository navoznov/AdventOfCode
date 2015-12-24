namespace Day19
{
    public class ReplacementRule
    {
        private readonly string _source;
        private readonly string _target;

        public ReplacementRule(string source, string target)
        {
            _source = source;
            _target = target;
        }

        public string Source
        {
            get { return _source; }
        }

        public string Target
        {
            get { return _target; }
        }
    }
}