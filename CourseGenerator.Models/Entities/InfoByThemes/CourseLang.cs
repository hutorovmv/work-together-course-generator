using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.InfoByThemes
{
    public class CourseLang
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int LangId { get; set; }
        public Language Lang { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
