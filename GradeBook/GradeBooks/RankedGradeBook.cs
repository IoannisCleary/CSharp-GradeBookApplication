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
            Dictionary<string, List<double>>  rankings = generateGradeRankins();
            if (rankings["Top20"].Contains(averageGrade))
            {
                return 'A';
            }
            else if (rankings["Top20To40"].Contains(averageGrade))
            {
                return 'B';
            }
            else if (rankings["Top40To60"].Contains(averageGrade))
            {
                return 'C';
            }
            else if (rankings["Top60To80"].Contains(averageGrade))
            {
                return 'D';
            }
            return 'F';
        }

        private Dictionary<string, List<double>> generateGradeRankins()
        {
            List<double> top20grades, top40grades, top60grades, top80grades;
            Dictionary<string, List<double>> rankings = new Dictionary<string, List<double>>();
            List<Student> sortedStudents = new List<Student>(Students);
            int twentyPercent = Students.Count / 5;
            sortedStudents.Sort();
            sortedStudents.Reverse();
            top20grades = new List<double>();
            for (int i = 0; i < twentyPercent; i++)
            {
                top20grades.Add(sortedStudents[i].AverageGrade);
            }
            rankings.Add("Top20", top20grades);
            top40grades = new List<double>();
            for (int i = twentyPercent; i < twentyPercent * 2; i++)
            {
                top40grades.Add(sortedStudents[i].AverageGrade);
            }
            rankings.Add("Top20To40", top20grades);
            top60grades = new List<double>();
            for (int i = twentyPercent * 2; i < twentyPercent * 3; i++)
            {
                top60grades.Add(sortedStudents[i].AverageGrade);
            }
            rankings.Add("Top40To60", top20grades);
            top80grades = new List<double>();
            for (int i = twentyPercent * 3; i < twentyPercent * 4; i++)
            {
                top80grades.Add(sortedStudents[i].AverageGrade);
            }
            rankings.Add("Top60To80", top20grades);
            return rankings;
        }
    }
}