namespace CourseGenerator.Models.Entities.Info
{
    public class OrganizationFormLang
    {
        public int OrganizationFormId { get; set; }
        public OrganizationForm OrganizationForm { get; set; }

        public string LangCode { get; set; }
        public Language Language { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
