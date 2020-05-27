using System;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.InfoByThemes;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class UserCourse
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int LevelNumber { get; set; }
        public Level Level { get; set; }

        public bool IsCompleted { get; set; }
        public DateTime LastTime { get; set; }

        public int? LastThemeId { get; set; }
        public Theme Theme { get; set; }

        public int Grade { get; set; }

        public string Note { get; set; }
    }
}
