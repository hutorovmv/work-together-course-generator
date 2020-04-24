using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Models
{
    public class UserRegistrationModel
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PreferedLangCode { get; set; }

        public string Password { get; set; }

        /// <summary>
        /// Can be useful when creating password validation on server
        /// </summary>
        public string PasswordConfirm { get; set; }
    }
}
