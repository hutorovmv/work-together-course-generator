using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoUrl { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? PreferedLangId { get; set; }
        public Language PreferedLang { get; set; }

        public ICollection<UserHeading> UserHeadings { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<UserTheme> UserThemes { get; set; }

        public User()
        {
            UserHeadings = new List<UserHeading>();
            UserCourses = new List<UserCourse>();
            UserThemes = new List<UserTheme>();
        }
    }
}
