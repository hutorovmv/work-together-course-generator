using System.Collections.Generic;

namespace CourseGenerator.Models.Entities.Info
{
    public class OrganizationForm
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public OrganizationForm Parent { get; set; }
        public ICollection<OrganizationForm> OrganizationForms { get; set; }

        public string Note { get; set; }

        public ICollection<OrganizationFormLang> OrganizationFormLangs { get; set; }
        public ICollection<MaterialOrganizationForm> MaterialOrganizationForms { get; set; }

        public OrganizationForm()
        {
            OrganizationForms = new List<OrganizationForm>();
            OrganizationFormLangs = new List<OrganizationFormLang>();
            MaterialOrganizationForms = new List<MaterialOrganizationForm>();
        }
    }
}
