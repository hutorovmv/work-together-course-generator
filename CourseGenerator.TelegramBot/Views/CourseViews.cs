using CourseGenerator.TelegramBot.Infrastructure;
using CourseGenerator.TelegramBot.Models;
using Nancy.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CourseGenerator.TelegramBot.Views
{
    public class CourseViews
    {
          public static string ltext;
        public static string courseSelectsStr="h";
        public void ShowUserCourses(IEnumerable<CourseSelectModel> courseSelects)
        {
            if (courseSelects != null)
            {

                //                Console.WriteLine("User courses collection:");
                ltext = "User courses collection:";

                CourseSelectModel courseSelect = new CourseSelectModel();
             //  string g = "45ygtdsfhdfh";

          //      if (courseSelect.Id == 1) g = courseSelect.Name;
                //Console.WriteLine(g);
                 courseSelectsStr = JsonConvert.SerializeObject(courseSelects, Formatting.Indented);
                

                Console.WriteLine(courseSelectsStr);
                ltext = ltext + courseSelectsStr;





           


            }
            else
            {
                //    Console.WriteLine("No data");
                ltext = "No data";
            }
            AppSettings.bot.OnMessage += BotOnMessageReceived1;
            AppSettings.bot.OnMessageEdited += BotOnMessageReceived1;
            AppSettings.bot.OnCallbackQuery += BotOnCallbackQueryReceived1;
            Console.WriteLine(ltext);

            AppSettings.bot.StartReceiving();
        }

        private static  void BotOnMessageReceived1(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;

            switch (message.Text)
            {
                case "":
                    {
                        break;
                    }
                default:
                    {
                        CourseSelectModel courseSelect = new CourseSelectModel();
                         AppSettings.bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                        #region Courses InlineKeyboard
                        //    List<InlineKeyboardButton> list = new List<InlineKeyboardButton>();
                           var courseSelects = JsonConvert
                           .DeserializeObject<IEnumerable<CourseSelectModel>>(courseSelectsStr);
                        //    foreach (var item in courseSelects)
                        //    {
                        //        list.Add(InlineKeyboardButton.WithCallbackData(Convert.ToString(item.Name))); 
                        //}
                        //    var inlineKeyboard = new InlineKeyboardMarkup(list);

                        #endregion

                        var buttons = courseSelects.Select(category => new[] { new KeyboardButton(Convert.ToString(category.Name)) })
    .ToArray();
                        var replyMarkup = new ReplyKeyboardMarkup(buttons);
                       
                        AppSettings.bot.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: "Виберіть курс із доступних 📚",
                            replyMarkup: replyMarkup);

                        break;

                    }

            }
        }
        

        private static async void BotOnCallbackQueryReceived1(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {

            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            await AppSettings.bot.SendTextMessageAsync(
                callbackQuery.Message.Chat.Id,
                $"Введіть код:");


        }
    }
}
