using Telegram.Bot.Polling;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using SchoolSchedule;

try
{
    var factory = Factory.GetInstance();
    Console.WriteLine("Запущен бот " + factory.Bot.GetMeAsync().Result.FirstName);

    var cts = new CancellationTokenSource();
    var cancellationToken = cts.Token;
    var receiverOptions = new ReceiverOptions
    {
        AllowedUpdates = { },
    };
    factory.Bot.StartReceiving(
        factory.TGService.HandleUpdateAsync,
        factory.TGService.HandleErrorAsync,
        receiverOptions,
        cancellationToken
    );
}
catch (Exception ex)
{
    Console.WriteLine( ex.ToString() );
}


Console.ReadLine();