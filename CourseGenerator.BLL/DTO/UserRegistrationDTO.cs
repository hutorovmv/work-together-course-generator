using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.BLL.DTO
{
    public class UserRegistrationDTO
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
