namespace CourseGenerator.Models.Entities.Info
{
    /// <summary>
    /// Націленість матеріалу на рівень компетентності
    /// </summary>
    public class MaterialCompetency
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int CompetencyId { get; set; }
        public Competency Competency { get; set; }

        public string Note { get; set; }
    }
}
