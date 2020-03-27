using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.InfoByThemes;
using CourseGenerator.Models.Entities.CourseAccess;

namespace CourseGenerator.Models.Entities.Info
{
    public class Heading
    {
        public int Id { get; set; }

        /// <summary>
        /// Код для побудови ієрархії
        /// </summary>
        public string Code { get; set; } 
        
        /// <summary>
        /// Код в універсальному десятковому класифікаторі
        /// </summary>
        public string UDC { get; set; }
        public string Note { get; set; }

        public ICollection<HeadingCompetency> HeadingCompetencies { get; set; }
        public ICollection<HeadingMaterial> HeadingMaterials { get; set; }
        public ICollection<ThemeHeading> ThemeHeadings { get; set; }
        public ICollection<UserHeading> UserHeadings { get; set; }
        public ICollection<CourseHeading> CourseHeadings { get; set; }
        public ICollection<HeadingLang> HeadingLangs { get; set; }

        public Heading()
        {
            HeadingCompetencies = new List<HeadingCompetency>();
            HeadingMaterials = new List<HeadingMaterial>();
            ThemeHeadings = new List<ThemeHeading>();
            UserHeadings = new List<UserHeading>();
            CourseHeadings = new List<CourseHeading>();
            HeadingLangs = new List<HeadingLang>();
        }
    }
}
