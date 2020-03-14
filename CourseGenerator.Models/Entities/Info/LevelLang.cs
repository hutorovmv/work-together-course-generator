using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class LevelLang
    {
        public int LevelId { get; set; }
        public Level Level { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public int LangId { get; set; }
        public Language Lang { get; set; }
    }
}
