namespace CourseGenerator.Models.Entities.Info
{
    public class LevelLang
    {
        public int LevelNumber { get; set; }
        public Level Level { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string LangCode { get; set; }
        public Language Lang { get; set; }
    }
}
