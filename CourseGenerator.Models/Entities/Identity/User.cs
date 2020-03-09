using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.Models.Entities.CourseAccess;

namespace CourseGenerator.Models.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }

        public ICollection<UserHeading> UserHeadings { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<UserTheme> UserThemes { get; set; }
    }
}
