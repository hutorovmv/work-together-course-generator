using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;

namespace CourseGenerator.TelegramBot.Infrastructure
{
    public class AppSettings
    {
        public string TelegramToken { get; set; }
        public static readonly TelegramBotClient bot = new TelegramBotClient(Program.BotToken);


    }
}
