using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class Level
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Note { get; set; }

        public ICollection<Competency> Competencies { get; set; }
       
    }
}
