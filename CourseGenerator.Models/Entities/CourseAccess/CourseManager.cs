using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class CourseManager
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public bool IsOwner { get; set; }
        public string Note { get; set; }
    }
}
