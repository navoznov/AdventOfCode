namespace Day06
{
    internal class LightsMap<T> where T : struct
    {
        private readonly int _width;
        private readonly int _height;
        private readonly T[,] _lights;

        public T this[int x, int y]
        {
            get { return _lights[x, y]; }
            set { _lights[x, y] = value; }
        }

        public LightsMap(int width, int height)
        {
            _width = width;
            _height = height;
            _lights = new T[width, height];
        }

        public int Width
        {
            get { return _width; }
        }

        public int Height
        {
            get { return _height; }
        }
    }
}