using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class CompetencyLang
    {
        public int CompetencyId { get; set; }
        public Competency Competency { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string LangCode { get; set; }
        public Language Lang { get; set; }


    }
}
