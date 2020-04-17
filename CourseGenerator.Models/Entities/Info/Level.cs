using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.InfoByThemes;
using CourseGenerator.Models.Entities.CourseAccess;


namespace CourseGenerator.Models.Entities.Info
{
    public class Level
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Note { get; set; }

        public ICollection<Competency> Competencies { get; set; }
        public ICollection<Theme> Themes { get; set; }
        public ICollection<UserHeading> UserHeadings { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }
        public ICollection<UserTheme> UserThemes { get; set; }
        public ICollection<LevelLang> LevelLangs { get; set; }

        public Level()
        {
            Competencies = new List<Competency>();
            Themes = new List<Theme>();
            UserHeadings = new List<UserHeading>();
            UserCourses = new List<UserCourse>();
            UserThemes = new List<UserTheme>();
            LevelLangs = new List<LevelLang>();
        }
    }
}
