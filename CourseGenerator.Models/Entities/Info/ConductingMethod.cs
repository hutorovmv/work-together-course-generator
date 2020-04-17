using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class ConductingMethod
    {
        public int Id { get; set; }

        public int ParentId { get; set; }
        public ConductingMethod Parent { get; set; }
        public ICollection<ConductingMethod> ConductingMethods { get; set; }

        public string Note { get; set; }

        public ICollection<ConductingMethodLang> ConductingMethodLangs { get; set; }
        public ICollection<MaterialConductingMethod> MaterialConductingMethods { get; set; }
        public ConductingMethod()
        {
            ConductingMethods = new List<ConductingMethod>();
            ConductingMethodLangs = new List<ConductingMethodLang>();
            MaterialConductingMethods = new List<MaterialConductingMethod>();
        }
    }
}
