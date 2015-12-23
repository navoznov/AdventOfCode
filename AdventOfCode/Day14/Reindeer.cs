using System;

namespace Day14
{
    internal class Reindeer 
    {
        public string Name { get; set; }
        public int Speed { get; set; }
        public int MovingTime { get; set; }
        public int RestTime { get; set; }

        public Reindeer(string name, int speed, int movingTime, int restTime)
        {
            Name = name;
            Speed = speed;
            MovingTime = movingTime;
            RestTime = restTime;
        }

        public int GetDistanceByTime(int time)
        {
            var iterationTime = MovingTime + RestTime;
            var remainderTime = time % iterationTime;
            var iterationsCount = (time-remainderTime)/iterationTime;
            var commonDistance = Speed*MovingTime * iterationsCount;
            var additionalDistance = Speed * Math.Min(MovingTime, remainderTime);
            return commonDistance + additionalDistance;
        }
    }
}