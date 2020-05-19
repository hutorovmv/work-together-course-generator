using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CourseGenerator.TelegramBot.BotActions;
using CourseGenerator.TelegramBot.Infrastructure;
using CourseGenerator.TelegramBot.Models;
using CourseGenerator.TelegramBot.Processors;
using CourseGenerator.TelegramBot.Views;
using Microsoft.Extensions.Logging;

namespace CourseGenerator.TelegramBot.Controllers
{
    public class AccountController
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AccountProcessor _accountProcessor;
        private readonly AccountViews _accountViews;
        private readonly UserAuthorization _userAuthorization;

        public AuthResponseModel temp=null;
        public static string code = null;



        public AccountController(ILogger<AccountController> logger,
            AccountProcessor accountProcessor,
            AccountViews accountViews, UserAuthorization userAuthorization)
        {
            _logger = logger;
            _accountProcessor = accountProcessor;
            _accountViews = accountViews;
            _userAuthorization = userAuthorization;
        }

        public void AuthorizeUser(ref AuthResponseModel userAuthData)

        {
            //string t = "";
            //while (t!= "Authorized")
            //{
            code=null;
                code = _accountViews.EnterLoginData();

                try
                {


                    temp = _accountProcessor.AuthenticateAsync(code).Result;
                AppSettings.bot.StopReceiving();

                if (temp != null)
                    {
                        _logger.LogInformation("Authorized");
                    //t = "Authorized";
                    userAuthData = temp;
                        _accountViews.ShowAuthResponse(userAuthData);

               //     _userAuthorization.MessageAuthentication(messageActiv);
                    return;
                    }

                    else
                    {
                        _logger.LogInformation("Unauthorized");
                
                   
                    return;
                    }


            


                //    AppSettings.bot.StopReceiving();


                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                
            //}
        }
        }
}
