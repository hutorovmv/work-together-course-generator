using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class Material
    {
        public int Id { get; set; }
        
        public int Number { get; set; }

        public string FileUrl { get; set; }
        public string BackImageUrl { get; set; }
        public string Url { get; set; }
        public string Note { get; set; }

        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }

        public int? ParentId { get; set; }
        public Material Parent { get; set; }
        public ICollection<Material> Competencies { get; set; }

        public ICollection<MaterialCompetency> MaterialCompetencies { get; set; }
        public ICollection<HeadingMaterial> HeadingMaterials { get; set; }
    }
}
