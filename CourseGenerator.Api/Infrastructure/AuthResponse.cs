using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Infrastructure
{
    public class AuthResponse
    {
        public string access_token { get; set; }
        public string userId { get; set; }
        public string userName { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string langCode { get; set; }
    }
}
