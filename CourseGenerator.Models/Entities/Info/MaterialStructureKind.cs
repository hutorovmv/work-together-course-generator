using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.Info
{
    public class MaterialStructureKind
    {
        public enum MaterialStructure {testCode1, testCode2, testCode3 }
        public MaterialStructure MaterialStructureCode { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }

    }
}
