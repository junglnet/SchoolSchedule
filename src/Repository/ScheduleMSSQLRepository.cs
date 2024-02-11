using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Entities;
using SchoolSchedule.Interfaces;
using SchoolSchedule.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Repository
{
    internal class ScheduleMSSQLRepository : IRepository<Schedule, SchelduleFilter>
    {
        private readonly ApplicationContext _db;

        public ScheduleMSSQLRepository(ApplicationContext db)
        {
            _db = db;
        }
        async public Task<IEnumerable<Schedule>> GetByQueryAsync(SchelduleFilter filter, CancellationToken token = default)
        {            
                var scheduleList = await _db.Schedules
                    .Select(item => new Schedule
                    {
                        GradeNumber = item.GradeNumber,
                        GradeLatter = item.GradeLatter,
                        Weekday = item.Weekday,
                        Cabinet = item.Cabinet,
                        TeacherName = item.TeacherName,
                        LessonName = item.LessonName,
                        LessonOrder = item.LessonOrder
                    })
                    .Where(item => item.Weekday == DateUtils.GetWeekDayNumber(filter.DayOfWeek))
                    .Where(item => item.GradeNumber == filter.GradeNumber)
                    .Where(item => item.GradeLatter == filter.GradeLatter)
                    .OrderBy(item => item.LessonOrder)
                    .ToListAsync();           
            
            return scheduleList;
        }
    }
}
