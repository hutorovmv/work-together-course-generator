using CourseGenerator.TelegramBot.BotActions;
using CourseGenerator.TelegramBot.Infrastructure;
using CourseGenerator.TelegramBot.Models;
using CourseGenerator.TelegramBot.Processors;
using CourseGenerator.TelegramBot.Views;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.TelegramBot.Controllers
{
    public class CourseController
    {
        private readonly ILogger<CourseController> _logger;
        private readonly CoursesProcessor _coursesProcessor;
        private readonly CourseViews _courseViews;
        private readonly UserAuthorization _userAuthorization;

     
        public CourseController(ILogger<CourseController> logger,
            CoursesProcessor coursesProcessor,
            CourseViews courseViews, UserAuthorization userAuthorization)
        {
            _logger = logger;
            _coursesProcessor = coursesProcessor;
            _courseViews = courseViews;
            _userAuthorization = userAuthorization;
        }

        public async void ShowUserCourses(AuthResponseModel authResponse)
        {
            AppSettings.bot.StopReceiving();
            try
            {
                if (authResponse == null)
                {
                    _logger.LogInformation("Unauthorized, so cannot get any courses");
    
                    //  temp = _accountProcessor.AuthenticateAsync(code).Result;
                    _userAuthorization.MessageAuthentication("Unauthorized");

                  

                    





                    return;
                }

                IEnumerable<CourseSelectModel> courseSelects = _coursesProcessor
                    .SelectCoursesAsync(authResponse.access_token, authResponse.langCode).Result;

                _courseViews.ShowUserCourses(courseSelects);
                _userAuthorization.MessageAuthentication("Authorized");
                
            }
            catch (Exception ex)
            {
                

                _logger.LogError(ex.Message);
            }
        }
    }
}
