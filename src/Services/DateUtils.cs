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

        public static int GetWeekDayNumber(DayOfWeek dayOfWeek)
        {

            return dayOfWeek switch
            {
                DayOfWeek.Monday => 1,
                DayOfWeek.Tuesday => 2,
                DayOfWeek.Wednesday => 3,
                DayOfWeek.Thursday => 4,
                DayOfWeek.Friday => 5,
                DayOfWeek.Saturday => 6,
                DayOfWeek.Sunday => 7,
                _ => throw new Exception("Такой день недели не найден"),
            };
        }

        public static string GetWeekDayRusName(int weekDayNum)
        {

            return weekDayNum switch
            {
                1 => "Понедельник",
                2 => "Вторник",
                3 => "Среда",
                4 => "Четверг",
                5 => "Пятница",
                6 => "Суббота",
                7 => "Воскресение",
                _ => throw new Exception("Такой день недели не найден"),
            };
        }

        

        
    }
}
