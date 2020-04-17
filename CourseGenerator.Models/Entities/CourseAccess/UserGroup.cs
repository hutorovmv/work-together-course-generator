using CourseGenerator.Models.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class UserGroup
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public bool IsActive { get; set; }
        public string Note { get; set; }
    }
}
