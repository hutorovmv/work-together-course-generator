using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class MaterialDependency
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int BaseMaterialId { get; set; }
        public Material BaseMaterial { get; set; }

        public string Note { get; set; }
    }
}
