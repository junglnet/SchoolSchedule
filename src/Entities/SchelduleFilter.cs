
namespace SchoolSchedule.Entities
{
    internal class SchelduleFilter
    {
        public int GradeNumber { get;}
        public string GradeLatter { get;}
        public DayOfWeek DayOfWeek { get;}
        public bool IsEmpty { get; }
        public SchelduleFilter(int gradeNumber, string  gradeLatter, DayOfWeek dayOfWeek)
        {
            GradeNumber = gradeNumber;
            GradeLatter = gradeLatter;
            DayOfWeek = dayOfWeek;
            IsEmpty = false;
        }

        public SchelduleFilter()
        {
            GradeNumber = 0;
            GradeLatter = "";
            DayOfWeek = DayOfWeek.Sunday;
            IsEmpty = true;
        }
    }
}
