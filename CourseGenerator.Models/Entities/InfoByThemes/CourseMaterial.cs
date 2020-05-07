using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.InfoByThemes
{
    public class CourseMaterial
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int PriorityLevel { get; set; }
        public bool IsReserved { get; set; }
        public string Note { get; set; }

    }
}
