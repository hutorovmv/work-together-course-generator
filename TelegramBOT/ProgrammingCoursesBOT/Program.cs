using System;
using Telegram.Bot;

namespace ProgrammingCoursesBOT
{
    class Program
    {
        static TelegramBotClient Bot;

        static void Main(string[] args)
        {
            Bot = new TelegramBotClient("1138286318:AAEorJo8vM8awMHFV7lipEiG-4z069e2RmI");

            Bot.OnMessage += Bot_OnMessage;

            var me = Bot.GetMeAsync().Result;

            Console.WriteLine(me.FirstName);

            Console.ReadLine();

            
        }

        private static void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message;

            Console.WriteLine(message.Text);
        }
    }
}
