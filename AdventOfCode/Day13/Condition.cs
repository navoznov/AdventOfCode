namespace Day13
{
    internal class Condition
    {
        public string SubjectName { get; set; }

        public int HappinessUnits { get; set; }

        public string ObjectName { get; set; }

        public Condition(string subjectName, string objectName, int happinessUnits)
        {
            SubjectName = subjectName;
            HappinessUnits = happinessUnits;
            ObjectName = objectName;
        }
    }
}