using Microsoft.EntityFrameworkCore;
using SchoolSchedule.Entities;
using SchoolSchedule.Interfaces;
using SchoolSchedule.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Repository
{
    internal class TeacherMSSQLRepository : IRepository<Schedule, TeacherFilter>
    {
        private readonly ApplicationContext _db;

        public TeacherMSSQLRepository(ApplicationContext db)
        {
            _db = db;
        }
        async public Task<IEnumerable<Schedule>> GetByQueryAsync(TeacherFilter  filter, CancellationToken token = default)
        {
            var teacherList = await _db.Schedules
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
                .Where(item => item.LessonName == filter.LessonName)
                .OrderBy(item => item.TeacherName)
                .ToListAsync();

            return teacherList.GroupBy(x => x.TeacherName).Select(x => x.First()).ToList();
        }
    }
}
