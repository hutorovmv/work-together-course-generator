namespace CourseGenerator.Models.Entities.Info
{
    public class MaterialBlock
    {
        public int? ParentId { get; set; }
        public Material ParentMaterial { get; set; }

        public int? ChildId { get; set; }
        public Material ChildMaterial { get; set; }

        public int Number { get; set; }
        public string Note { get; set; }
    }
}
