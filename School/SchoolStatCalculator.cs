using System;
using System.Collections.Generic;
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
            double gpa = 0;
            int count = 0;
            bool subjectFound = false;
            Classroom foundClassroom = null;

            foreach (var classroom in _classrooms)
            {
                if (classroom.Subject == subject)
                {
                    subjectFound = true;
                    foundClassroom = classroom;

                    foreach (var person in classroom)
                    {
                        if (person is Student)
                        {
                            count++;
                            gpa += ((Student)person).Gpa;
                        }
                    }
                }
            }

            if (!subjectFound)
            {
                throw new MissingSubjectException(subject);
            }

            if (count == 0)
            {
                throw new EmptyClassroomException(foundClassroom);
            }

            return gpa / count;
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
