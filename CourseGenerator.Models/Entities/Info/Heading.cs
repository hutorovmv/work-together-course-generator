using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Entities.Info
{
    public class Heading
    {
        public string Id { get; set; }
        public string Code { get; set; }
        public string UDC { get; set; }
        public string Note { get; set; }

        public ICollection<HeadingCompetency> HeadingCompetencies { get; set; }
        public ICollection<HeadingMaterial> HeadingMaterials { get; set; }
        public ICollection<ThemeHeading> ThemeHeadings { get; set; }
    }
}
