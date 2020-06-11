using CourseGenerator.TelegramBot.Infrastructure;
using CourseGenerator.TelegramBot.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace CourseGenerator.TelegramBot.Processors
{
    public class CoursesProcessor
    {
        private readonly ILogger<CoursesProcessor> _logger;

        public CoursesProcessor(ILogger<CoursesProcessor> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<CourseSelectModel>> SelectCoursesAsync(string token, string langCode = "eng")
        {
            _logger.LogInformation("Loading courses for authorized user...");

            _logger.LogTrace("Forming query...");
            // Creates query
            NameValueCollection query = HttpUtility.ParseQueryString(string.Empty);
            query["langCode"] = langCode;

            _logger.LogTrace("Creating Url...");
            Uri url = new Uri(ApiHelper.ApiClient.BaseAddress, "api/courses");
            // Creates builder with base address
            UriBuilder builder = new UriBuilder(url);
            // Sets query
            builder.Query = query.ToString();

            string urlWithQuery = builder.ToString();
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, urlWithQuery))
            {
                _logger.LogTrace($"Setting Authorization header: \"Bearer {token}\"...");
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                //request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                _logger.LogTrace($"Sending request to \"{url}\"...");
                HttpResponseMessage response = await ApiHelper.ApiClient.SendAsync(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string courseSelectsStr = await response.Content.ReadAsStringAsync();
                    IEnumerable<CourseSelectModel> courseSelects = JsonConvert
                        .DeserializeObject<IEnumerable<CourseSelectModel>>(courseSelectsStr);

                    return courseSelects;
                }

                if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    _logger.LogInformation("Unauthorized");
                    return null;
                }

                throw new Exception($"Unexpected { response.StatusCode } status code;");
            }
        }
    }
}

