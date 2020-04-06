using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.InfoByThemes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class UserTheme
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int ThemeId { get; set; }
        public Theme Theme { get; set; } 

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public bool IsCompleted { get; set; }
        public int Grade { get; set; }

        public string Note { get; set; }
    }
}
