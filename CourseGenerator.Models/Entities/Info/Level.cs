using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Entities.Info
{
    public class Level
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Note { get; set; }

        public ICollection<Competency> Competencies { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Theme> Themes { get; set; }
        public ICollection<ThemeHeading> ThemeHeadings { get; set; }
    }
}
