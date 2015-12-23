using System.Collections.Generic;
using System.Linq;

namespace Day13
{
    internal class Conditions
    {
        private readonly List<Condition> _conditions;

        public Conditions(List<Condition> conditions)
        {
            _conditions = conditions;
        }

        public List<Condition> GetBySubjectName(string subjectName)
        {
            return _conditions.Where(x => x.SubjectName == subjectName).ToList();
        }
        public Condition GetBySubjectAndObjectNames(string subjectName, string objectName)
        {
            return _conditions.Single(x => x.SubjectName == subjectName && x.ObjectName==objectName);
        }

        public void Add(Condition condition)
        {
            _conditions.Add(condition);
        }
    }
}