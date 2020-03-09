using GradeBook.Enums;
using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool weighted) : base(name, weighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            int nrOfStudents = Students.Count;
            var studentCopy = new List<Student>(Students);
            studentCopy.Sort((s1, s2) => s2.AverageGrade.CompareTo(s1.AverageGrade));
            if (studentCopy[nrOfStudents / 5 - 1].AverageGrade <= averageGrade)
            {
                return 'A';
            }
            else if (studentCopy[2 * nrOfStudents / 5 - 1].AverageGrade <= averageGrade)
            {
                return 'B';
            }
            else if (studentCopy[3 * nrOfStudents / 5 - 1].AverageGrade <= averageGrade)
            {
                return 'C';
            }
            else if (studentCopy[4 * nrOfStudents / 5 - 1].AverageGrade <= averageGrade)
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
