using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class HeadingCompetency
    {
        // TODO: Визначити первинний ключ
        public int HeadingId { get; set; }
        public Heading Heading { get; set; }

        public int CompetencyId { get; set; }
        public Competency Competency { get; set; }

        public string Note { get; set; }
    }
}
