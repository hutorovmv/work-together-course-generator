using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Security
{
    public class CodeAuth
    {
        public string UserId { get; set; }

        public string Code { get; set; }
    }
}
