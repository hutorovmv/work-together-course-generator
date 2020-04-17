using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class ConductingMethodLang
    {
        public int ConductingMethodId { get; set; }
        public ConductingMethod ConductingMethod { get; set; }

        public string LangCode { get; set; }
        public Language Language { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

    }
}
