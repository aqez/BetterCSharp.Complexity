using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BetterCSharp.Complexity.School.People;

namespace BetterCSharp.Complexity.School
{
    public enum Subject { Math, Reading, SocialStudies, Science };
    public class Classroom : IEnumerable<IPerson>
    {
        public Subject Subject { get; set; }
        private List<IPerson> _people;

        public Classroom(Subject subject, IEnumerable<IPerson> people)
        {
            Subject = subject;
            _people = people.ToList();
        }

        public void AddPerson(IPerson person)
        {
            _people.Add(person);
        }

        public IEnumerator<IPerson> GetEnumerator()
        {
            return _people.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
