using SchoolSchedule.Entities;
using SchoolSchedule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Services
{
    internal class ScheduleService
    {
        private readonly  IRepository<Schedule,SchelduleFilter> _scheduleRepository;
        private readonly IRepository<Schedule, TeacherFilter> _teacherRepository;
        public ScheduleService (IRepository<Schedule, SchelduleFilter> scheduleRepository, IRepository<Schedule, TeacherFilter> teacherRepository)
        {
            _scheduleRepository = scheduleRepository;
            _teacherRepository = teacherRepository;
        }

        public async Task<IEnumerable<Schedule>> GetByQueryAsync(SchelduleFilter filter, CancellationToken token = default)
        {
            return await _scheduleRepository.GetByQueryAsync(filter, token);
        }

        public async Task<IEnumerable<Schedule>> GetByQueryAsync(TeacherFilter filter, CancellationToken token = default)
        {
            return await _teacherRepository.GetByQueryAsync(filter, token);
        }

        public async Task<string> GetScheldueString(SchelduleFilter filter, CancellationToken token = default)
        {
            if (filter.IsEmpty)
            {
                return string.Empty;
            }
            var schedules = await GetByQueryAsync(filter, token);           
            string response = string.Empty;
            
            foreach (var schedule in schedules)
            {
                if (response == string.Empty)
                {                    
                    response = $"Расписание для {schedule.GradeNumber} \"{schedule.GradeLatter}\" на {DateUtils.GetWeekDayRusName(schedule.Weekday)}:" + Environment.NewLine;                                       
                }
                response = response + schedule.ToString() + Environment.NewLine;
            }
            if (response == string.Empty)
            {
                response = "Ничего не найдено!";
            }
            return response;

        }

        public async Task<string> GetTeacherName(TeacherFilter filter, CancellationToken token = default)
        {
            if (filter.IsEmpty) { 
                return string.Empty;
            }

            var teachers = await GetByQueryAsync(filter, token);
            string response = string.Empty;

            foreach (var teacher in teachers)
            {
                if (response == string.Empty)
                {
                    response = $"{teacher.LessonName}, найденные учителя:" + Environment.NewLine;
                }
                response = response + teacher.TeacherName + Environment.NewLine;
            }
            if (response == string.Empty)
            {
                response = "Ничего не найдено!";
            }
            return response;

        }
    }
}
