namespace Day11
{
    /// <summary>
    /// Passwords must include one increasing straight of at least three letters, like abc, bcd, cde, and so on, up to xyz. They cannot skip letters; abd doesn't count.
    /// </summary>
    internal class HasIncreasingStraightRule : IRule
    {
        public bool Check(string str)
        {
            var chars = str.ToCharArray();
            for (var i = 0; i < chars.Length - 2; i++)
            {
                var char1 = chars[i];
                var char2 = chars[i + 1];
                var char3 = chars[i + 2];
                if (char1 + 1 == char2 && char2 + 1 == char3)
                {
                    return true;
                }
            }
            return false;
        }
    }
}