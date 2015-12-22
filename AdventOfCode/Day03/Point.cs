namespace Day03
{
    internal struct Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            return X == other.X && Y == other.Y;
        }
    }
}