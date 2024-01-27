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
        private readonly  IRepository<Schedule> _scheduleRepository;
        public ScheduleService (IRepository<Schedule> scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<IEnumerable<Schedule>> GetByQueryAsync(Query query, CancellationToken token = default)
        {
            return await _scheduleRepository.GetByQueryAsync(query, token);
        }

        public async Task<string> GetScheldueString(Query query, CancellationToken token = default)
        {
            var schedules = await GetByQueryAsync(query, token);           
            string response = string.Empty;
            
            foreach (var schedule in schedules)
            {
                if (response == string.Empty)
                {                    
                    response = "Расписание для " + schedule.GradeNumber + schedule.GradeLatter + " на " 
                        + DateUtils.GetWeekDayRusName(schedule.Weekday) + ":" + Environment.NewLine;
                }
                response = response + schedule.ToString() + Environment.NewLine;
            }

            return response;

        }
    }
}
