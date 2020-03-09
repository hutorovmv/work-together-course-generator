using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Info.Entities
{
    public class MaterialTypeLang
    {
        public int Id { get; set; }
        
        public int LangId { get; set; }
        public Language Lang { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
