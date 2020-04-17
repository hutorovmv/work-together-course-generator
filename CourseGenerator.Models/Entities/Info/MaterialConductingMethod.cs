using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class MaterialConductingMethod
    {
        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public int ConductingMethodId { get; set; }
        public ConductingMethod ConductingMethod { get; set; }

        public string Note { get; set; }
    }
}
