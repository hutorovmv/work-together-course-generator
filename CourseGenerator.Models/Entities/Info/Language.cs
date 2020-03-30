using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Entities.Info
{
    public class Language
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string OriginalName { get; set; }
        public string Note { get; set; }

        public ICollection<HeadingLang> HeadingLangs { get; set; }
        public ICollection<LevelLang> LevelLangs { get; set; }
        public ICollection<CompetencyLang> CompetencyLangs { get; set; }
        public ICollection<MaterialTypeLang> MaterialTypeLangs { get; set; }
        public ICollection<MaterialLang> MaterialLangs { get; set; }
        public ICollection<CourseLang> CourseLangs { get; set; }
        public ICollection<ThemeLang> ThemeLangs { get; set; }
        public ICollection<User> Users { get; set; }

        public Language()
        {
            HeadingLangs = new List<HeadingLang>();
            LevelLangs = new List<LevelLang>();
            CompetencyLangs = new List<CompetencyLang>();
            MaterialTypeLangs = new List<MaterialTypeLang>();
            MaterialLangs = new List<MaterialLang>();
            CourseLangs = new List<CourseLang>();
            ThemeLangs = new List<ThemeLang>();
            Users = new List<User>();
        }
    }
}
