using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using CourseGenerator.TelegramBot.Models;
using CourseGenerator.TelegramBot.Infrastructure;
using Microsoft.Extensions.Logging;
using CourseGenerator.TelegramBot.Views;

namespace CourseGenerator.TelegramBot.Processors
{
    public class AccountProcessor
    {
        private readonly ILogger<AccountProcessor> _logger;
        private readonly AccountViews _accountViews;


        public AccountProcessor(ILogger<AccountProcessor> logger, AccountViews accountViews)
        {
            _accountViews = accountViews;
            _logger = logger;
        }

        //public async Task<AuthResponseModel> AuthenticateAsync(CodeAuthModel authModel)
        //{
        //    _logger.LogInformation("Authentication...");

        //    string serializedAuthModel = JsonConvert.SerializeObject(authModel);
        //    HttpContent httpContent = new StringContent(serializedAuthModel, Encoding.UTF8,
        //        "application/json");
        //    _logger.LogTrace($"Credentials: {serializedAuthModel}");

        //    using (HttpResponseMessage response = await ApiHelper.ApiClient
        //        .PostAsync("api/account/authenticate", httpContent))
        //    {
        //        if (response.StatusCode == HttpStatusCode.OK)
        //        {
        //            _logger.LogInformation("Authorized");
        //            var authResponseStr = await response.Content.ReadAsStringAsync();
        //            return JsonConvert.DeserializeObject<AuthResponseModel>(authResponseStr);
        //        }

        //        if (response.StatusCode == HttpStatusCode.Unauthorized)
        //        {
        //            _logger.LogInformation("Unauthorized");
        //            return null;
        //        }

        //        throw new Exception($"Unexpected { response.StatusCode } status code;");
        //    }
        //}

        public async Task<AuthResponseModel> AuthenticateAsync(string code)
        {
           // int i = 1;
          
                _logger.LogInformation("Authentication with code...");

                HttpContent httpContent = new StringContent(code, Encoding.UTF8,
                    "application/json"); // TODO: change to text/plainapplication/json
                _logger.LogTrace($"Code: {code}");


                using (HttpResponseMessage response = await ApiHelper.ApiClient
                    .PostAsync("api/authentication/code", httpContent))
                {

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        _logger.LogInformation("Authorized");
                        var authResponseStr = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<AuthResponseModel>(authResponseStr);
                    }

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        _logger.LogInformation("Unauthorized");
                       // return null;
                    }

                    if (response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var authResponseStr = await response.Content.ReadAsStringAsync();
                        _logger.LogWarning(authResponseStr);
                    }
                    if (response.StatusCode == HttpStatusCode.UnsupportedMediaType)
                    {
                        var authResponseStr = await response.Content.ReadAsStringAsync();
                        _logger.LogWarning(authResponseStr);
                    }

                    throw new Exception($"Unexpected { response.StatusCode } status code;");
                  //  code = _accountViews.EnterLoginData();
                
            }
        }
    }
}
