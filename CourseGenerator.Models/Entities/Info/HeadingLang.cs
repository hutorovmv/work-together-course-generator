namespace CourseGenerator.Models.Entities.Info
{
    public class HeadingLang
    {
        public int HeadingId { get; set; }
        public Heading Heading { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public string LangCode { get; set; }
        public Language Lang { get; set; }
    }
}
