using SchoolSchedule.Services;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// 10 Х 10.11(вывод расписание на 10.11)
// 10 Х Вторник
// 10 Х (вывод расписания на сегодняшний день)
// Вывод
// 1.: история, к310, Бучнева Мария Андреевна


var str = Console.ReadLine();
try
{
    var query = IOService.ParseInputString(str);

    Console.WriteLine(query.GradeNumber + " " + query.GradeLatter + " " + query.DayOfWeek.ToString());

}
catch (Exception e)
{

    Console.WriteLine(e.Message);
}
