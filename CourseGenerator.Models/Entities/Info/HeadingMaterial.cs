namespace CourseGenerator.Models.Entities.Info
{
    /// <summary>
    /// Закріплення матеріалу за рубрикою
    /// </summary>
    public class HeadingMaterial
    {
        public int HeadingId { get; set; }
        public Heading Heading { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public string Note { get; set; }
    }
}
