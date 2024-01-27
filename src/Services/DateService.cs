using SchoolSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSchedule.Services
{
    internal class DateUtils
    {
        public static DayOfWeek ParseStringToWeekDay(string parseString)
        {

            if (DateTime.TryParse(parseString, out DateTime dateTime))
            {
                return dateTime.DayOfWeek;
            }

            try
            {
                return GetWeekDayRusName(parseString);
            }
            catch (Exception)
            {

                throw;
            }

        }

        public static string GetWeekDayRusName(int weekDayNum)
        {

            return weekDayNum switch
            {
                2 => "Понедельник",
                3 => "Вторник",
                4 => "Среда",
                5 => "Четверг",
                6 => "Пятница",
                7 => "Суббота",
                0 => "Воскресение",
                _ => throw new Exception("The weekday is not found"),
            };
        }

        public static DayOfWeek GetWeekDayRusName(string weekDayName)
        {

            return weekDayName switch
            {
               "Понедельник" => DayOfWeek.Monday,
               "Вторник" => DayOfWeek.Tuesday,
               "Среда" => DayOfWeek.Wednesday,
               "Четверг" => DayOfWeek.Thursday,
               "Пятница" => DayOfWeek.Friday,
               "Суббота" => DayOfWeek.Saturday,
               "Воскресение" => DayOfWeek.Sunday,
                _ => throw new Exception("The weekday is not found"),
            };
        }

        public static string GetWeekDayRusName(DayOfWeek dayOfWeek)
        {

            return dayOfWeek switch
            {
                DayOfWeek.Monday => "Понедельник",
                DayOfWeek.Tuesday => "Вторник",
                DayOfWeek.Wednesday => "Среда",
                DayOfWeek.Thursday => "Четверг",
                DayOfWeek.Friday => "Пятница",
                DayOfWeek.Saturday => "Суббота",
                DayOfWeek.Sunday => "Воскресение",
                _ => throw new Exception("The weekday is not found"),
            };
        }
    }
}
