using System;
using System.Linq;
using GradeBook.Enums;

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

            int threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var gradesInDescendingOrderQuery = Students.OrderByDescending(s => s.AverageGrade).Select(s => s.AverageGrade).ToList();
            System.Collections.Generic.List<double> gradesInDescendingOrder = gradesInDescendingOrderQuery;

            if (averageGrade >= gradesInDescendingOrder[threshold - 1])
                return 'A';
            if (averageGrade >= gradesInDescendingOrder[(threshold * 2) - 1])
                return 'B';
            if (averageGrade >= gradesInDescendingOrder[(threshold * 3) - 1])
                return 'C';
            if (averageGrade >= gradesInDescendingOrder[(threshold * 4) - 1])
                return 'D';
            return 'F';
        }
    }
}