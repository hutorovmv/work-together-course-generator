using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.Info;

namespace CourseGenerator.Models.Entities.InfoByThemes
{
    /// <summary>
    /// Рубрики теми (вибираються з рубрик курсу)
    /// </summary>
    public class ThemeHeading
    {
        public int ThemeId { get; set; }
        public Theme Theme { get; set; }

        public int HeadingId { get; set; }
        public Heading Heading { get; set; }

        public string Note { get; set; }
    }
}
