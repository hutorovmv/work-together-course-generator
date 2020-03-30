using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.InfoByThemes
{
    /// <summary>
    /// Матеріал теми (вибираються з матеріалів рубрик теми 
    /// з врахуванням рівня складності)
    /// </summary>
    public class ThemeMaterial
    {
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int Number { get; set; }
        public string Note { get; set; }
    }
}
