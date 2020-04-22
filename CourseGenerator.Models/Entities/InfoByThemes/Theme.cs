using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.InfoByThemes
{
    public class Theme
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int LevelNumber { get; set; }
        public Level Level { get; set; }

        /// <summary>
        /// Якщо в тему включений матеріал, то вона
        /// не може бути батьківською 
        /// </summary>
        public int? ParentId { get; set; }
        public Theme Parent { get; set; }
        public ICollection<Theme> Themes { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int Number { get; set; }
        public string Note { get; set; }


        public ICollection<UserTheme> UserThemes { get; set; }
        public ICollection<ThemeLang> ThemeLangs { get; set; }
        public ICollection<UserCourse> UserCourses { get; set; }

        public Theme()
        {
            Themes = new List<Theme>();
            UserThemes = new List<UserTheme>();
            ThemeLangs = new List<ThemeLang>();
            UserCourses = new List<UserCourse>();
        }
    }
}
