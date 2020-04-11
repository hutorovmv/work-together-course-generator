using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Security
{
    public class PhoneAuth
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
}
