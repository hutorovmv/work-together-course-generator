using System.Collections.Generic;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Entities.Info
{
    public class Language
    {
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
        public ICollection<OrganizationFormLang> OrganizationFormLangs { get; set; }
        public ICollection<ConductingMethodLang> ConductingMethodLangs { get; set; }
        public ICollection<UserLanguagePriority> UserLanguagePriorities { get; set; }

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
            OrganizationFormLangs = new List<OrganizationFormLang>();
            ConductingMethodLangs = new List<ConductingMethodLang>();
            UserLanguagePriorities = new List<UserLanguagePriority>();
        }
    }
}
