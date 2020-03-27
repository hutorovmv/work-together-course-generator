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

        public int LevelId { get; set; }
        public Level Level { get; set; }

        public int? ParentId { get; set; }
        public Theme Parent { get; set; }
        public ICollection<Theme> Themes { get; set; }

        public string Note { get; set; }

        public ICollection<ThemeHeading> ThemeHeadings { get; set; }
        public ICollection<ThemeMaterial> ThemeMaterials { get; set; }
        public ICollection<UserTheme> UserThemes { get; set; }
        public ICollection<ThemeLang> ThemeLangs { get; set; }

        public Theme()
        {
            Themes = new List<Theme>();
            ThemeHeadings = new List<ThemeHeading>();
            UserThemes = new List<UserTheme>();
            ThemeLangs = new List<ThemeLang>();
        }
    }
}
