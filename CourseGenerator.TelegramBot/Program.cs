using CourseGenerator.TelegramBot.BotActions;
using CourseGenerator.TelegramBot.Controllers;
using CourseGenerator.TelegramBot.Infrastructure;
using CourseGenerator.TelegramBot.Models;
using CourseGenerator.TelegramBot.Processors;
using CourseGenerator.TelegramBot.Views;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Threading;

namespace CourseGenerator.TelegramBot
{
    class Program
    {
        private static ILogger<Program> logger;
        private static AuthResponseModel userAuthData;
        public  static string BotToken ;
        public static int  first = 0;
       public static int last = 1;

        //public static string BotToken="";

        public Program()
        {
            userAuthData = new AuthResponseModel();
        }

        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                  .AddLogging(options =>
                  {

                      options.AddFilter(typeof(AccountProcessor).FullName, LogLevel.Trace); //LogLevel.Trace
                    options.AddFilter(typeof(CoursesProcessor).FullName, LogLevel.Trace); //LogLevel.Trace
                    options.AddFilter(typeof(Program).FullName, LogLevel.Trace); //LogLevel.Trace
                    options.AddConsole(); // Add logging to console
                })
                  .AddSingleton<AccountProcessor>()
                  .AddSingleton<CoursesProcessor>()
                  .AddSingleton<AccountViews>()
                  .AddSingleton<UserAuthorization>()
                  .AddSingleton<CourseViews>()
                  .AddSingleton<AccountController>()
                  .AddSingleton<CourseController>()
                  .BuildServiceProvider();
            var config = new ConfigurationBuilder()
          .SetBasePath(Environment.CurrentDirectory)
          .AddJsonFile("appsettings.json")
          .AddUserSecrets("c1050377-05eb-41cd-869a-e255668af125")
          .Build();

            var appSettings = config.GetSection("General").Get<AppSettings>();

            //logger.LogTrace($"Telegram Api Key: {appSettings.TelegramToken ?? "null"}");
            BotToken = appSettings.TelegramToken;
           // logger.LogTrace($"Test configuration value: {config["General:DummyOption"]}");

            Start();
            Console.ReadKey(true);
        }

        public static void Start()
        {
            UserAuthorization.lActiv = null;

            // Add DI container and put logging in it
            var serviceProvider = new ServiceCollection()
                .AddLogging(options =>
                {

                    options.AddFilter(typeof(AccountProcessor).FullName, LogLevel.Trace); //LogLevel.Trace
                    options.AddFilter(typeof(CoursesProcessor).FullName, LogLevel.Trace); //LogLevel.Trace
                    options.AddFilter(typeof(Program).FullName, LogLevel.Trace); //LogLevel.Trace
                    options.AddConsole(); // Add logging to console
                })
                .AddSingleton<AccountProcessor>()
                .AddSingleton<CoursesProcessor>()
                .AddSingleton<AccountViews>()
                .AddSingleton<UserAuthorization>()
                .AddSingleton<CourseViews>()
                .AddSingleton<AccountController>()
                .AddSingleton<CourseController>()
                .BuildServiceProvider();

                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                logger = loggerFactory.CreateLogger<Program>();
                logger.LogInformation("Application is starting...");

                logger.LogTrace($"Current directory: {Environment.CurrentDirectory}");



                #region authentication
                //ILogger<AccountProcessor> accountLogger = loggerFactory
                //.CreateLogger<AccountProcessor>();
                //AccountProcessor accountProcessor = new AccountProcessor(accountLogger);

                //try
                //{
                //    userAuthData = await accountProcessor.AuthenticateAsync(new UserLoginModel
                //    {
                //        UserName = "andrewryzhkov@gmail.com",
                //        Password = "Andruha123!"
                //    });
                //}
                //catch (Exception ex)
                //{
                //    logger.LogError(ex.Message);
                //}
                #endregion

                #region courses for user
                //ILogger<CoursesProcessor> coursesLogger = loggerFactory
                //.CreateLogger<CoursesProcessor>();
                //CoursesProcessor coursesProcessor = new CoursesProcessor(coursesLogger);

                //try
                //{
                //    IEnumerable<CourseSelectModel> courseSelects = await coursesProcessor
                //        .SelectCoursesAsync(userAuthData.access_token, userAuthData.langCode);
                //}
                //catch (Exception ex)
                //{
                //    logger.LogError(ex.Message);
                //}
                #endregion

                AccountController accountController = serviceProvider
                    .GetService<AccountController>();

                CourseController courseController = serviceProvider
                    .GetService<CourseController>();

                //Thread.Sleep(100);
                accountController.AuthorizeUser(ref userAuthData);
                courseController.ShowUserCourses(userAuthData);
               
            }
        }
    }
