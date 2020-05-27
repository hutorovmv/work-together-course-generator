namespace CourseGenerator.Models.Entities.Info
{
    public class MaterialDependencyKind
    {
        public enum MaterialDependency { Code1,Code2,Code3 };
        public MaterialDependency MaterialDependencyCode { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
    }
}
