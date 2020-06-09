using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.InfoByThemes;
using System;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class UserCourseMessage
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }
    }
}
