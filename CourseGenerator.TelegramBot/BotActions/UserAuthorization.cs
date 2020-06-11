using CourseGenerator.TelegramBot.Controllers;
using CourseGenerator.TelegramBot.Infrastructure;
using CourseGenerator.TelegramBot.Models;
using CourseGenerator.TelegramBot.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CourseGenerator.TelegramBot.BotActions
{
    public class UserAuthorization
    {
        private readonly ILogger<UserAuthorization> _logger;

        public UserAuthorization(ILogger<UserAuthorization> logger
            )
        {
            _logger = logger;
        }
        public static string uniqueCode=null;
        public static int i = 0;
        public static string lActiv=null;

        #region entering unique code

        public string EnterUniqueCode()
        {
            AppSettings.bot.OnMessage += BotOnMessageReceivedCodeAsync;
            AppSettings.bot.OnMessageEdited += BotOnMessageReceivedCodeAsync;
            AppSettings.bot.OnCallbackQuery += BotOnCallbackQueryReceivedAuthorized;
            uniqueCode = null;
            AppSettings.bot.StartReceiving();
            int a = 1;

            while (a >= 1)
            {
                     if (uniqueCode != "/start" && uniqueCode !=null) a-- ;

            }
                return uniqueCode;

        }

        private static async void BotOnMessageReceivedCodeAsync(object sender, MessageEventArgs messageEventArgs)
        {

            var message = messageEventArgs.Message;

            if (message == null || message.Type != MessageType.Text) return;
           

                switch (message.Text)
            {
                //case "Авторизуватися🧩":
                //    {
                //        if(lActiv== "Unauthorized")
                //        {
                //            lActiv = "";
                //            AccountController.code = "";
                //            Program.last++;
                //            Program.Start();
                //        }
                   
                //        break;
                //    }

                    case "/start":
                        {
                      //      await AppSettings.bot.SendTextMessageAsync(
                      //    message.Chat.Id,
                      //    "Для доступу до курсів необхідно авторизуватися." +
                      //    " Для авторизації Вам потрібно перейти на веб сайті" +
                      //    " та згенерувати одноразовий код(Код авторизації " +
                      //    "потрібно вводити в лапках)."

                      //);


                        ReplyKeyboardMarkup ReplyKeyboard = new[]
               {
                        new[] { "Авторизуватися🧩" }
                    };
                     await    AppSettings.bot.SendTextMessageAsync(
                            chatId: message.Chat.Id,
                            text: "⚠️Для доступу до курсів необхідно авторизуватися." +
                          " Для авторизації Вам потрібно перейти на веб сайті" +
                          " та згенерувати одноразовий код(Код авторизації " +
                          "потрібно вводити в лапках)." +
                          " Після надсилання коду натисніть ◀️Авторизуватися🧩▶️",
                            replyMarkup: ReplyKeyboard);



                        break;
                        }
                    default:
                    {
                        // if (message.Text != "Авторизуватися🧩") { }
                        if (message.Text != "Авторизуватися🧩" && message.Text.StartsWith('"') && message.Text.EndsWith('"'))
                        {
                            uniqueCode = message.Text;
                           // AppSettings.bot.StopReceiving();

                        }

                        else 
                        {

                            if (lActiv != "Authorized" && lActiv != "Unauthorized" && message.Text!= "Авторизуватися🧩")
                            {
                                
                             await AppSettings.bot.SendTextMessageAsync(
                             message.Chat.Id,
                             "⛔️Код був введений некоректно. ");

                                  
                                    await AppSettings.bot.SendTextMessageAsync(
                             message.Chat.Id,
                             "❗️Перевірте, будь ласка, наявність лапок.");
                                   
                                 
                                }
                              
                            }
                       
                        }


                        break;








                    }
            


        }

        private static async void BotOnCallbackQueryReceivedAuthorized(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;

            await AppSettings.bot.AnswerCallbackQueryAsync(
                callbackQueryId: callbackQuery.Id,
                text: "Авторизуватися🧩"
            );



        }
        #endregion

        #region message authentication
        // message authentication
        public string MessageAuthentication(string messageActiv)
        {
            lActiv = messageActiv;
            AppSettings.bot.OnMessage += BotOnMessageReceivedMessage;
            AppSettings.bot.OnMessageEdited += BotOnMessageReceivedMessage;
           
           AppSettings.bot.StartReceiving();

           
            return "";

        }

        private static async void BotOnMessageReceivedMessage(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;

            // if (message == null || message.Type != MessageType.Text) return;

         
                if (message.Text == "Авторизуватися🧩" )//&& uniqueCode != null)
                {
                UserAuthorization.i = 0;


                switch (lActiv)
                    {
                        case "Authorized":
                        {
                            if (lActiv != null)
                            {
                                lActiv = null;
                                await AppSettings.bot.SendTextMessageAsync(
                              message.Chat.Id,
                              "Привіт😀 " + AccountViews.user

                          );


                            }
                                break;
                            }
                        case "Unauthorized":
                            {

                           
                                if (lActiv != null)
                                {

                            lActiv = null;
                                await AppSettings.bot.SendTextMessageAsync(
                                  message.Chat.Id,
                                  "🚷⭕️📛 Вас не авторизовано"


                              );
                                    await AppSettings.bot.SendTextMessageAsync(
                                  message.Chat.Id,
                                  "🔒Спробуйте ще раз"
                                  
                              );
                                    AppSettings.bot.StopReceiving();
                                }

                            
                         
                            AccountController.code = null;
                            Program.Start();

                            break;

                        }
                    default:
                            {
                                //if (message.Text != "/start" && message.Text != "Авторизуватися")

                                
                                break;




                            }



                    }
                }
            
        }

        private static async void BotOnCallbackQueryReceivedMessage(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            var callbackQuery = callbackQueryEventArgs.CallbackQuery;





        }


        #endregion

    }
}
