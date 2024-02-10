
namespace SchoolSchedule.Entities
{
    internal class TeacherFilter
    {
        public string LessonName { get; }
        public bool IsEmpty { get; }

        public TeacherFilter(string lessonName)
        {
            LessonName = lessonName;
            IsEmpty = false;
        }

        public TeacherFilter()
        {
            LessonName = "";
            IsEmpty = true;
        }
    }

    
}
