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
        public static DayOfWeek StringDateToWeekDay(string parseString = "Undefined")
        {

            if (parseString == "Undefined")
            {
                return DateTime.Now.DayOfWeek;
            }

            if (DateTime.TryParse(parseString, out DateTime dateTime))
            {
                return dateTime.DayOfWeek;
            }

            throw new Exception("Фрмат даты неверный!");
        }
        public static DayOfWeek StringRusWeekNameToWeekDay(string weekDayName)
        {
            
            return weekDayName.ToLower() switch
            {
                "понедельник" => DayOfWeek.Monday,
                "вторник" => DayOfWeek.Tuesday,
                "среда" => DayOfWeek.Wednesday,
                "четверг" => DayOfWeek.Thursday,
                "пятница" => DayOfWeek.Friday,
                "суббота" => DayOfWeek.Saturday,
                "воскресение" => DayOfWeek.Sunday,
                _ => throw new Exception("Такой день недели не найден"),
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
                _ => throw new Exception("Такой день недели не найден"),
            };
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
                _ => throw new Exception("Такой день недели не найден"),
            };
        }

        

        
    }
}
