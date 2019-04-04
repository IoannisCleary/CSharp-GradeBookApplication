using System;
using System.Collections.Generic;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            int twentyPercent = Students.Count / 5;
            List<Student> sortedStudents = new List<Student>(Students);
            sortedStudents.Sort();
            sortedStudents.Reverse();
            List<double> top20grades = new List<double>();
            for (int i = 0; i < twentyPercent; i++)
            {
                top20grades.Add(sortedStudents[i].AverageGrade);
            }
            List<double> top40grades = new List<double>();
            for (int i = twentyPercent; i < twentyPercent * 2; i++)
            {
                top40grades.Add(sortedStudents[i].AverageGrade);
            }
            List<double> top60grades = new List<double>();
            for (int i = twentyPercent * 2; i < twentyPercent * 3; i++)
            {
                top60grades.Add(sortedStudents[i].AverageGrade);
            }
            List<double> top80grades = new List<double>();
            for (int i = twentyPercent * 3; i < twentyPercent * 4; i++)
            {
                top80grades.Add(sortedStudents[i].AverageGrade);
            }
            if (top20grades.Contains(averageGrade))
            {
                return 'A';
            }
            else if (top40grades.Contains(averageGrade))
            {
                return 'B';
            }
            else if (top60grades.Contains(averageGrade))
            {
                return 'C';
            }
            else if (top80grades.Contains(averageGrade))
            {
                return 'D';
            }
            return 'F';
        }
    }
}