using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using System;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class UserMaterialMessage
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public string Message { get; set; }
        public DateTime DateTime { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }
    }
}
