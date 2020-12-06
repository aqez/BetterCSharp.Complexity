using System;
using System.Collections.Generic;
using System.Linq;
using BetterCSharp.Complexity.School.People;

namespace BetterCSharp.Complexity.School
{
    public class SchoolStatCalculator
    {
        private IEnumerable<Classroom> _classrooms;

        public SchoolStatCalculator(IEnumerable<Classroom> classrooms)
        {
            _classrooms = classrooms;
        }

        public double GetAverageGpa(Subject subject)
        {
            Classroom classroom = _classrooms.FirstOrDefault(c => c.Subject == subject);

            if (classroom == null)
            {
                throw new MissingSubjectException(subject);
            }

            if (!classroom.Any())
            {
                throw new EmptyClassroomException(classroom);
            }

            return classroom.OfType<Student>().Average(s => s.Gpa);
        }
    }

    public class EmptyClassroomException : Exception
    {
        public Classroom Classroom { get; }

        public EmptyClassroomException(Classroom classroom) : base($"The classroom {classroom} has no students")
        {
            Classroom = classroom;
        }
    }

    public class MissingSubjectException : Exception
    {
        public Subject Subject { get; }

        public MissingSubjectException(Subject subject) : base($"{nameof(Subject)} {subject} was not found")
        {
            Subject = subject;
        }
    }
}
