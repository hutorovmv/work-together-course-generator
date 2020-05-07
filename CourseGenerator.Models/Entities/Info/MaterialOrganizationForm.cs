namespace CourseGenerator.Models.Entities.Info
{
    public class MaterialOrganizationForm
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int OrganizationFormId { get; set; }
        public OrganizationForm OrganizationForm { get; set; }

        public string Note { get; set; }
    }
}
