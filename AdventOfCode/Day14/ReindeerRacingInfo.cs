namespace Day14
{
    internal class ReindeerRacingInfo
    {
        public Reindeer Reindeer { get; set; }
        public int CurrentDistance { get; set; }

        public int BonusValue { get; set; }

        public ReindeerRacingInfo(Reindeer reindeer)
        {
            Reindeer = reindeer;
            CurrentDistance = 0;
            BonusValue = 0;
        }
    }
}