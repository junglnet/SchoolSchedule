using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Entities
{
    internal class Schedule
    {
        public int GradeNumber { get; set; }
        public string GradeLatter { get; set; }
        public string Cabinet { get; set;}
        public string TeacherName { get; set; }
        public string LessonName { get; set; }
        public int Weekday { get; set; }
        public int LessonOrder { get; set; }

        public override string ToString()
        {
            return LessonOrder.ToString() + ". " + LessonName + ", каб. " + Cabinet + ", " + TeacherName;
        }

    }
}
