using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18
{
    internal class LightsMatrix
    {
        public readonly int Size;
        private readonly bool[,] _lights;

        public virtual bool this[int x, int y]
        {
            get { return _lights[x + 1, y + 1]; }
            set { _lights[x + 1, y + 1] = value; }
        }

        public LightsMatrix(int size)
        {
            Size = size;
            _lights = new bool[size + 2, size + 2];
        }

        public virtual LightsMatrix New()
        {
            return new LightsMatrix(Size);
        }

        public IEnumerable<bool> GetNeighbors(int x, int y)
        {
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }
                    yield return this[x + i, y + j];
                }
            }
        }

        public int GetTurnedOnLightsCount()
        {
            var counter = 0;
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    if (this[i, j])
                    {
                        counter++;
                    }
                }
            }
            return counter;
        }

        public virtual bool GetNextLightState(int x, int y)
        {
            var currentLight = this[x, y];
            var neighborsCountThatOn = GetNeighbors(x, y).Count(n => n);
            if (currentLight && (neighborsCountThatOn == 2 || neighborsCountThatOn == 3))
            {
                return true;
            }
            if (!currentLight && neighborsCountThatOn == 3)
            {
                return true;
            }
            return false;
        }

        public void Print()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    Console.Write(this[j, i] ? "#" : ".");
                }
                Console.WriteLine();
            }
        }
    }
}