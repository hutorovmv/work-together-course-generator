using System;
using System.Collections.Generic;
using System.Text;
using CourseGenerator.Models.Entities.InfoByThemes;

namespace CourseGenerator.Models.Entities.Info
{
    public class Material
    {
        public int Id { get; set; }
        
        public int Number { get; set; }

        /// <summary>
        /// Файл з мультимедійним контентом
        /// </summary>
        public string FileUrl { get; set; }

        /// <summary>
        /// Фон секції
        /// </summary>
        public string BackImageUrl { get; set; }

        /// <summary>
        /// Посилання на джерело
        /// </summary>
        public string Url { get; set; }
        public string Note { get; set; }

        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }

        public int? ParentId { get; set; }
        public Material Parent { get; set; }
        public ICollection<Material> Materials { get; set; }

        public ICollection<MaterialCompetency> MaterialCompetencies { get; set; }
        public ICollection<HeadingMaterial> HeadingMaterials { get; set; }
        public ICollection<ThemeMaterial> ThemeMaterials { get; set; }
        public ICollection<MaterialLang> MaterialLangs { get; set; }

        public Material()
        {
            Materials = new List<Material>();
            MaterialCompetencies = new List<MaterialCompetency>();
            HeadingMaterials = new List<HeadingMaterial>();
            ThemeMaterials = new List<ThemeMaterial>();
            MaterialLangs = new List<MaterialLang>();
        }
    }
}
