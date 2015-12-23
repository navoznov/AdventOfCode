using System.Collections.Generic;

namespace Day13
{
    internal class Table
    {
        public List<string> People { get; set; }

        public Table(List<string> people)
        {
            People = people;
        }

        public int CalcTotalHappiness(Conditions conditions)
        {
            var totalHappiness = 0;
            for (int i = 0; i < People.Count; i++)
            {
                var subjectName = People[i];
                string objectNameLeft;
                string objectNameRight;
                GetNeighbors(i, out objectNameLeft, out objectNameRight);
                totalHappiness += conditions.GetBySubjectAndObjectNames(subjectName, objectNameLeft).HappinessUnits;
                totalHappiness += conditions.GetBySubjectAndObjectNames(subjectName, objectNameRight).HappinessUnits;
            }
            return totalHappiness;
        }

        private void GetNeighbors(int currentPosition, out string objectNameLeft, out string objectNameRight)
        {
            if (currentPosition == 0)
            {
                objectNameLeft = People[People.Count - 1];
                objectNameRight = People[currentPosition + 1];
            }
            else if (currentPosition == People.Count - 1)
            {
                objectNameLeft = People[currentPosition - 1];
                objectNameRight = People[0];
            }
            else
            {
                objectNameRight = People[currentPosition + 1];
                objectNameLeft = People[currentPosition - 1];
            }
        }
    }
}