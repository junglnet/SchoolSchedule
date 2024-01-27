using SchoolSchedule.Services;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// 10 Х 10.11(вывод расписание на 10.11)
// 10 Х Вторник
// 10 Х (вывод расписания на сегодняшний день)
// Вывод
// 1.: история, к310, Бучнева Мария Андреевна

string s = "27.01";

try
{
    var result = DateUtils.ParseStringToWeekDay(s);
    Console.WriteLine(result.ToString());
}
catch (Exception e)
{

    Console.WriteLine(e.Message);
}


