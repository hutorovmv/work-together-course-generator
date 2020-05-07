namespace CourseGenerator.Models.Entities.InfoByThemes
{
    public class CourseDependencyKind
    {
        public enum CourseDependency { Code1,Code2,Code3 }
        public CourseDependency CourseDependencyCode { get; set; }

        public string Name { get; set; }
        public string Note { get; set; }
    }
}
