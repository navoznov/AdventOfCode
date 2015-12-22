using System;

namespace Day03
{
    internal struct DirectionVector
    {
        internal readonly static DirectionVector Up = new DirectionVector(0,1);
        internal readonly static DirectionVector Down = new DirectionVector(0,-1);
        internal readonly static DirectionVector Left = new DirectionVector(-1,0);
        internal readonly static DirectionVector Right = new DirectionVector(1,0);

        private int X { get; set; }

        private int Y { get; set; }

        private DirectionVector(int x, int y) : this()
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return String.Format("[{0}; {1}].", X, Y);
        }

        public static Point operator +(DirectionVector directionVector, Point point)
        {
            return new Point(point.X + directionVector.X, point.Y + directionVector.Y);
        }

        public static Point operator +(Point point, DirectionVector directionVector)
        {
            return directionVector + point;
        }

        internal static DirectionVector ParseDirection(char directionChar)
        {
            switch (directionChar)
            {
                case '^':
                    return DirectionVector.Up;
                case 'v':
                    return DirectionVector.Down;
                case '<':
                    return DirectionVector.Left;
                case '>':
                    return DirectionVector.Right;
            }
            throw new ArgumentOutOfRangeException("directionChar");
        }
    }
}