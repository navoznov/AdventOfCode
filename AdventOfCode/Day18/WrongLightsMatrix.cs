using System.Linq;

namespace Day18
{
    internal class WrongLightsMatrix : LightsMatrix
    {
        public WrongLightsMatrix(int size) : base(size)
        {
        }

        public override LightsMatrix New()
        {
            return new WrongLightsMatrix(Size);
        }

        public override bool this[int x, int y]
        {
            get
            {
                if ((x == 0 || x == Size - 1) && (y == 0 || y == Size - 1))
                {
                    return true;
                }
                return base[x, y];
            }
            set { base[x, y] = value; }
        }
    }
}