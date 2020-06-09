using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.InfoByThemes
{
    public class ThemeLang
    {
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }

        public string LangCode { get; set; }
        public Language Lang { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
