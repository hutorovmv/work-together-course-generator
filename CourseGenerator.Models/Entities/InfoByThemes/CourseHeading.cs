using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.InfoByThemes
{
    /// <summary>
    /// Рубрики навчального курсу
    /// </summary>
    public class CourseHeading
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int HeadingId { get; set; }
        public Heading Heading { get; set; }

        public bool IsBasic { get; set; }
        public string Note { get; set; }
    }
}
