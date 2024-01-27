using SchoolSchedule.Entities;
using SchoolSchedule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Repository
{
    internal class ScheduleRepository : IRepository<Schedule>
    {
        async public Task<IEnumerable<Schedule>> GetByQueryAsync(Query query, CancellationToken token = default)
        {
            var scheduleList = new List<Schedule>();
            var schedule = new Schedule
            {
                GradeNumber = 10,
                GradeLatter = "Г",
                LessonName = "История",
                TeacherName = "Иванов Иван Иванович",
                Cabinet = "304",
                Order = 1,
                Weekday = 2
            };
            var schedule1 = new Schedule
            {
                GradeNumber = 10,
                GradeLatter = "Г",
                LessonName = "Физика",
                TeacherName = "Петров Петр Петрович",
                Cabinet = "304",
                Order = 2,
                Weekday = 2
            };

            scheduleList.Add(schedule);
            scheduleList.Add(schedule1);

            return scheduleList;
        }
    }
}
