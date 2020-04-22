using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.Identity;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    /// <summary>
    /// Початковий рівень користувача (користувач вказує рівень для рубрик)
    /// </summary>
    public class UserHeading
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int HeadingId { get; set; }
        public Heading Heading { get; set; }

        public int LevelNumber { get; set; }
        public Level Level { get; set; }

        public string Note { get; set; }


    }
}
