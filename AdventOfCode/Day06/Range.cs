namespace Day06
{
    internal struct Range
    {
        public Point From;
        public Point To;

        public Range(Point @from, Point to)
        {
            From = @from;
            To = to;
        }
    }
}