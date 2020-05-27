using CourseGenerator.Models.Entities.Identity;
using System;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class GroupMessage
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }

        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }
    }
}
