using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;

namespace SchoolSchedule.Services
{
    internal class TGService
    {
        private string STARTMESSAGE = "Добро пожаловать!" 
            + Environment.NewLine + "Пример доступных команд:" 
            + Environment.NewLine + "10 Ю 10.11" 
            + Environment.NewLine + "10 Ю 10.11.24"
            + Environment.NewLine + "10 Ю Вторник"
            + Environment.NewLine + "10 Ю";

        private readonly ScheduleService _scheduleService;

        public TGService(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                var message = update.Message;
                if (message.Text.ToLower() == "/start")
                {
                    
                    await botClient.SendTextMessageAsync(message.Chat, STARTMESSAGE);
                    return;
                }

                try
                {
                    var schelduleFilter = IOService.ParseInputStringToSchelduleFilter(message.Text.ToLower());
                    var response = await _scheduleService.GetScheldueString(schelduleFilter, cancellationToken);

                    if (response == string.Empty)
                    {
                        var teacherFilter = IOService.ParseInputStringToTeacherFilter(message.Text.ToLower());
                        response = await _scheduleService.GetTeacherName(teacherFilter, cancellationToken);
                    }                    

                    if (response == string.Empty)
                    {
                        response = "Формат введенной строки неверный!";
                    }

                    await botClient.SendTextMessageAsync(message.Chat, response);

                }
                catch (Exception e)
                {
                    await botClient.SendTextMessageAsync(message.Chat, e.Message);
                    
                }
            }
        }

        public async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }
    }
}
