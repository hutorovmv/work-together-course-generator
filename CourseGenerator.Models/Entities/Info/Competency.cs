using System.Collections.Generic;

namespace CourseGenerator.Models.Entities.Info
{
    public class Competency
    {
        public int Id { get; set; }
        public string Note { get; set; }

        public int? ParentId { get; set; }
        public Competency Parent { get; set; }
        public ICollection<Competency> Competencies { get; set; }

        public int LevelNumber { get; set; }
        public Level Level { get; set; }

        public ICollection<HeadingCompetency> HeadingCompetencies { get; set; }
        public ICollection<MaterialCompetency> MaterialCompetencies { get; set; }
        public ICollection<CompetencyLang> CompetencyLangs { get; set; }

        public Competency()
        {
            Competencies = new List<Competency>();
            HeadingCompetencies = new List<HeadingCompetency>();
            MaterialCompetencies = new List<MaterialCompetency>();
            CompetencyLangs = new List<CompetencyLang>();
        }
    }
}
