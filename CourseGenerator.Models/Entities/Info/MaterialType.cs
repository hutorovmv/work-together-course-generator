using System.Collections.Generic;

namespace CourseGenerator.Models.Entities.Info
{
    public class MaterialType
    {
        public int Id { get; set; }

        public string Note { get; set; }

        public int? ParentId { get; set; }
        public MaterialType Parent { get; set; }

        public ICollection<MaterialType> MaterialTypes { get; set; }
        public ICollection<Material> Materials { get; set; }
        public ICollection<MaterialTypeLang> MaterialTypeLangs { get; set; }

        public MaterialType()
        {
            MaterialTypes = new List<MaterialType>();
            Materials = new List<Material>();
            MaterialTypeLangs = new List<MaterialTypeLang>();
        }
    }
}
