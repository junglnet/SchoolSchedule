using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Entities
{
    internal class Query
    {
        public int GradeNumber { get;}
        public string GradeLatter { get;}
        public DayOfWeek DayOfWeek { get;}
        public Query(int gradeNumber, string  gradeLatter, DayOfWeek dayOfWeek)
        {
            GradeNumber = gradeNumber;
            GradeLatter = gradeLatter;
            DayOfWeek = dayOfWeek;
        }
    }
}
