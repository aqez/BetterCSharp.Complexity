using System;
using BetterCSharp.Complexity.School.People;

namespace BetterCSharp.Complexity.School
{

    class Program
    {
        static void Main(string[] args)
        {
            var classrooms = new Classroom[]
            {
                new Classroom(Subject.Math,
                        new IPerson[]
                        {
                            new Teacher(),
                            new Student() { Gpa = 4.0 },
                            new Student() { Gpa = 3.0 }
                        }),
                new Classroom(Subject.Reading,
                        new IPerson[]
                        {
                            new Teacher(),
                            new Student() { Gpa = 2.0 },
                            new Student()  { Gpa = 3.8 }
                        }),
                new Classroom(Subject.Science,
                        new IPerson[]
                        {
                            new Teacher(),
                            new Student() { Gpa = 3.5 },
                            new Student()  { Gpa = 3.2 }
                        }),
                new Classroom(Subject.SocialStudies,
                        new IPerson[]
                        {
                            new Teacher(),
                            new Student() { Gpa = 1.0 },
                            new Student()  { Gpa = 4.0 }
                        }),
            };

            SchoolStatCalculator calculator = new SchoolStatCalculator(classrooms);

            double gpa = calculator.GetAverageGpa(Subject.Science);
            Console.WriteLine($"The GPA average for {nameof(Subject.Science)} is {gpa}.");
        }
    }
}
