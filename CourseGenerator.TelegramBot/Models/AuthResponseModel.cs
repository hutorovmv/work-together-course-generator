using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.TelegramBot.Models
{
    public class AuthResponseModel
    {
        public string access_token { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string langCode { get; set; }
    }
}
