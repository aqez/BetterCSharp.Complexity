using System.Collections.Generic;
using System.Linq;
using BetterCSharp.Complexity.School;
using BetterCSharp.Complexity.School.People;
using Xunit;

namespace School.Tests
{
    public class SchoolStatCalculatorTest
    {
        [Fact]
        public void GetAverageGpa_WithValidClasses_GivesBackCorrectAverage()
        {
            // Arrange
            Classroom[] classrooms = new Classroom[]
            {
                new Classroom(Subject.Math, new IPerson[] { new Teacher(), new Student() { Gpa = 4.0 }, new Student() { Gpa = 3.0 } }),
            };
            SchoolStatCalculator calculator = new SchoolStatCalculator(classrooms);

            // Act
            double averageGpa = calculator.GetAverageGpa(Subject.Math);

            // Assert
            Assert.Equal(3.5, averageGpa);
        }


        [Fact]
        public void GetAverageGpa_WithNoClassrooms_ThrowsMissingSubjectException()
        {
            // Arrange
            IEnumerable<Classroom> classrooms = Enumerable.Empty<Classroom>();
            SchoolStatCalculator calculator = new SchoolStatCalculator(classrooms);

            // Act
            MissingSubjectException exception = Assert.Throws<MissingSubjectException>(() => calculator.GetAverageGpa(Subject.Math));

            // Assert
            Assert.Equal(Subject.Math, exception.Subject);
        }

        [Fact]
        public void GetAverageGpa_WithEmptyClassroom_ThrowsEmptyClassroomException()
        {
            // Arrange
            Classroom[] classrooms = new Classroom[]
            {
                new Classroom(Subject.Math, new IPerson[] { }),
            };
            SchoolStatCalculator calculator = new SchoolStatCalculator(classrooms);

            // Act
            EmptyClassroomException exception = Assert.Throws<EmptyClassroomException>(() => calculator.GetAverageGpa(Subject.Math));

            // Assert
            Assert.Equal(classrooms[0], exception.Classroom);

        }
    }
}
