﻿using SchoolSchedule.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SchoolSchedule.Services
{
    internal class IOService
    {
        public static Query ParseInputString(string inputString)
        {
            
            string patternWithWeekDay = @"^[0-9]*\s[а-яё]\s[а-яё]+$";
            string patternShort = @"^[0-9]*\s[а-яё]$";
            string patternShortDate = @"^[0-9]*\s[а-яё]\s\d{2}\.\d{2}$";
            string patternFullDate = @"^[0-9]*\s[а-яё]\s\d{2}\.\d{2}\.\d{4}$";
            string patternDate = @"^[0-9]*\s[а-яё]\s\d{2}\.\d{2}\.\d{2}$";
            DayOfWeek dayOfWeek;

            if (Regex.IsMatch(inputString, patternWithWeekDay, RegexOptions.IgnoreCase))
            {
                var inputStrings = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                dayOfWeek = DateUtils.StringRusWeekNameToWeekDay(inputStrings[2]);

                return new Query(int.Parse(inputStrings[0]), inputStrings[1], dayOfWeek);

            }

            if (Regex.IsMatch(inputString, patternShort, RegexOptions.IgnoreCase))
            {
                var inputStrings = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                dayOfWeek = DateUtils.StringDateToWeekDay();

                return new Query(int.Parse(inputStrings[0]), inputStrings[1], dayOfWeek);

            }

            if (Regex.IsMatch(inputString, patternShortDate, RegexOptions.IgnoreCase) 
                || Regex.IsMatch(inputString, patternFullDate, RegexOptions.IgnoreCase) 
                || Regex.IsMatch(inputString, patternDate, RegexOptions.IgnoreCase))
            {
                var inputStrings = inputString.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                dayOfWeek = DateUtils.StringDateToWeekDay(inputStrings[2]);

                return new Query(int.Parse(inputStrings[0]), inputStrings[1], dayOfWeek);

            }

            throw new Exception("Формат введенной строки неверный!");


        }
    }
}
