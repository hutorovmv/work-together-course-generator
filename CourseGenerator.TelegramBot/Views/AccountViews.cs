using CourseGenerator.TelegramBot.BotActions;
using CourseGenerator.TelegramBot.Infrastructure;
using CourseGenerator.TelegramBot.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace CourseGenerator.TelegramBot.Views
{
    public class AccountViews
    {
        private static readonly TelegramBotClient bot = new TelegramBotClient(Program.BotToken);
       
        private readonly ILogger<AccountViews> _logger;
        private readonly UserAuthorization _userAuthorization;

 
        public static string user;


        public AccountViews(ILogger<AccountViews> logger, UserAuthorization userAuthorization)
        {
            _logger = logger;
            _userAuthorization = userAuthorization;
        }



        public string EnterLoginData()
        {
            #region For using in console
            _logger.LogInformation("Enter UniqueCode:");
            // Console.Write("Enter UniqueCode: ");
            //string UniqueCode = Console.ReadLine();
            //return UniqueCode;
            #endregion
            string uniqueCode = _userAuthorization.EnterUniqueCode();

            return uniqueCode;
        }







        #region Auth Response
        public void ShowAuthResponse(AuthResponseModel authResponse)
        {
           // bot.StopReceiving();
            _logger.LogInformation("Auth response:");
         
           
            if (authResponse != null)
            {
                string authResponseStr = JsonConvert.SerializeObject(authResponse, Formatting.Indented);
                Console.WriteLine(authResponseStr);
                user = authResponse.firstName + " "+ authResponse.lastName;
                AppSettings.bot.StopReceiving();

                return;

            }
         
                _logger.LogInformation("Unauthorized1");
           

            //  if (lActiv != "Auth response:") EnterLoginData();
        }
        #endregion
    }
}