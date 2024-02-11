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
        public IRepository<Schedule,SchelduleFilter> ScheduleRepository { get;}
        public IRepository<Schedule, TeacherFilter> TeacherRepository { get; }
        public ScheduleService ScheduleService { get; }
        public TGService TGService { get; }
        public ApplicationContext DB {  get; }

        private static Factory instance;
        private Factory()
        {
            var bot = new TelegramBotClient("6847951172:AAEjwHfxnURQiH8M7gHQZ6QOqM1K09qW5Mw");
            var db = new ApplicationContext("Server=.;Database=schoolscheldule;Trusted_Connection=True;TrustServerCertificate=True;");
            var scheldueRepository = new ScheduleMSSQLRepository(db);
            var teacherRepository = new TeacherMSSQLRepository(db);
            var scheduleService = new ScheduleService(scheldueRepository, teacherRepository);
            var tgBot = new TGService(scheduleService);

            Bot = bot;
            ScheduleRepository = scheldueRepository;
            TeacherRepository = teacherRepository;
            ScheduleService = scheduleService;
            TGService = tgBot;
            DB = db;
        }

        public static Factory GetInstance()
        {
            if (instance == null)
                instance = new Factory();
            return instance;
        }

    }
}
