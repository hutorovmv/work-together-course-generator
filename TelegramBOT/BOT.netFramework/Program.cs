using System;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace BOT.netFramework
{
    class Program
    {
        static TelegramBotClient Bot;

        static void Main(string[] args)
        {
            Bot = new TelegramBotClient("1138286318:AAEorJo8vM8awMHFV7lipEiG-4z069e2RmI");

            Bot.OnMessage += Bot_OnMessage;
            Bot.OnCallbackQuery += BotOnCallbackQueryReceive;
            var me = Bot.GetMeAsync().Result;

            Console.WriteLine(me.FirstName);

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();


        }

        private static void BotOnCallbackQueryReceive(object sender, Telegram.Bot.Args.CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

      

        private static async void Bot_OnMessage(object sender, Telegram.Bot.Args.MessageEventArgs e)
        {
            var message = e.Message;

            if (message == null || message.Type != MessageType.Text) 
                return;

            string name = $"{message.From.FirstName} {message.From.LastName}";

            Console.WriteLine($"{name} надіслав: {message.Text}");

            switch (message.Text)
            {
                case "/start":
                    string text =
                        @"/start-
                        /g
                        /g
                        /g";
                    await  Bot.SendTextMessageAsync(message.From.Id, text);
                    break;

                case "/category":
                    var inlineKeyboard = new InlineKeyboardMarkup(new[]
                    {
                        new[]
                        {
                            InlineKeyboardButton.WithCallbackData("1"),
                            InlineKeyboardButton.WithCallbackData("2"),
                            InlineKeyboardButton.WithCallbackData("3")

                        },

                         new[]
                        {
                            InlineKeyboardButton.WithCallbackData("4"),
                            InlineKeyboardButton.WithCallbackData("5"),
                            InlineKeyboardButton.WithCallbackData("6")

                        }
                    });
                    await Bot.SendTextMessageAsync(message.From.Id, "Виберіть пункт меню", replyMarkup: inlineKeyboard);
                    break;





            }
        }
    }
}
