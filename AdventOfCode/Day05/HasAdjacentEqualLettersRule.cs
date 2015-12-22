namespace Day05
{
    internal class HasAdjacentEqualLettersRule : IRule
    {
        public bool Check(string str)
        {
            var chars = str.ToCharArray();
            for (var i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}