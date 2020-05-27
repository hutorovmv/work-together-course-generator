namespace CourseGenerator.Models.Entities.InfoByThemes
{
    public class CourseDependency
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public CourseDependency CourseDependencyCode { get; set; }

        public int BaseCourseId { get; set; }
        public Course BaseCourse { get; set; }

        public string Note { get; set; }
    }
}
