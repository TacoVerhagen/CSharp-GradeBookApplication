using GradeBook.Enums;
using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            int nrOfStudents = Students.Count;
            Students.Sort((s1, s2) => s2.AverageGrade.CompareTo(s1.AverageGrade));
            if (Students[nrOfStudents / 5 - 1].AverageGrade <= averageGrade)
            {
                return 'A';
            }
            else if (Students[2 * nrOfStudents / 5 - 1].AverageGrade <= averageGrade)
            {
                return 'B';
            }
            else if (Students[3 * nrOfStudents / 5 - 1].AverageGrade <= averageGrade)
            {
                return 'C';
            }
            else if (Students[4 * nrOfStudents / 5 - 1].AverageGrade <= averageGrade)
            {
                return 'D';
            }
            return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}
