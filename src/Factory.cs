using SchoolSchedule.Entities;
using SchoolSchedule.Interfaces;
using SchoolSchedule.Repository;
using SchoolSchedule.Services;
using Telegram.Bot;

namespace SchoolSchedule
{
    internal class Factory
    {

        public ITelegramBotClient Bot { get;}
        public IRepository<Schedule> ScheduleRepository { get;}
        public ScheduleService ScheduleService { get; }
        public TGService TGService { get; }

        private static Factory instance;
        private Factory()
        {
            var bot = new TelegramBotClient("6847951172:AAEjwHfxnURQiH8M7gHQZ6QOqM1K09qW5Mw");
            var scheldueRepository = new ScheduleRepository();
            var scheduleService = new ScheduleService(scheldueRepository);
            var tgBot = new TGService(scheduleService);

            Bot = bot;
            ScheduleRepository = scheldueRepository;
            ScheduleService = scheduleService;
            TGService = tgBot;
        }

        public static Factory GetInstance()
        {
            if (instance == null)
                instance = new Factory();
            return instance;
        }

    }
}
