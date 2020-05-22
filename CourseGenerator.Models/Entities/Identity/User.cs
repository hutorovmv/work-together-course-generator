using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.Identity
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhotoId { get; set; }
        public DateTime? BirthDate { get; set; }
        public string PreferedLangCode { get; set; }
        public Language PreferedLang { get; set; }
        public DateTime RegistrationDate { get; set; }

        public ICollection<UserHeading> UserHeadings { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<UserTheme> UserThemes { get; set; }
        public ICollection<UserMaterial> UserMaterials { get; set; }
        public ICollection<UserMaterialResult> UserMaterialResults { get; set; }
        public ICollection<UserMaterialMessage> UserMaterialMessages { get; set; }
        public ICollection<UserMaterialMessage> SenderMessages { get; set; }
        public ICollection<UserGroup> UserGroups { get; set; }
        public ICollection<GroupMessage> GroupMessages { get; set; }
        public ICollection<UserCourseMessage> UserCourseMessages { get; set; }
        public ICollection<UserCourseMessage> SenderCourseMessages { get; set; } 
        public ICollection<UserLanguagePriority> UserLanguagePriorities { get; set; }
        public ICollection<HeadingManager> HeadingManagers { get; set; }
        public ICollection<MaterialManager> MaterialManagers { get; set; }
        public ICollection<CourseManager> CourseManagers { get; set; }
        public User()
        {
            UserHeadings = new List<UserHeading>();
            UserCourses = new List<UserCourse>();
            UserThemes = new List<UserTheme>();
            UserMaterials = new List<UserMaterial>();
            UserMaterialResults = new List<UserMaterialResult>();
            UserMaterialMessages = new List<UserMaterialMessage>();
            SenderMessages = new List<UserMaterialMessage>();
            UserGroups = new List<UserGroup>();
            GroupMessages = new List<GroupMessage>();
            UserCourseMessages = new List<UserCourseMessage>();
            SenderCourseMessages = new List<UserCourseMessage>();
            UserLanguagePriorities = new List<UserLanguagePriority>();
            HeadingManagers = new List<HeadingManager>();
            MaterialManagers = new List<MaterialManager>();
            CourseManagers = new List<CourseManager>();
        }
    }
}
