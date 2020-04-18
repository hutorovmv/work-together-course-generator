using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Security
{
    public class PhoneAuth
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}
