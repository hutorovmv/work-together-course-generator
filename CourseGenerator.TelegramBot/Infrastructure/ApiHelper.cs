using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CourseGenerator.TelegramBot.Infrastructure
{
    public static class ApiHelper
    {
        // Static property contains HttpClient to avoid creating and disposing
        // time spends.
        public static HttpClient ApiClient { get; set; }

        static ApiHelper()
        {
            // To prevent SSL certificate error
            HttpClientHandler clientHandler = new HttpClientHandler(); // Creating new client handler
            // Making SSL check always successful
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true;

            ApiClient = new HttpClient(clientHandler); // Creating new HTTP client
            ApiClient.BaseAddress = new Uri("https://localhost:44343/"); // Base Url for requests

            // Clearing types which are engaged in content negotiation
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            // Now our client preferes json data
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
