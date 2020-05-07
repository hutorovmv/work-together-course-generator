using System.Collections.Generic;
using CourseGenerator.Models.Entities.CourseAccess;
using CourseGenerator.Models.Entities.InfoByThemes;
using static CourseGenerator.Models.Entities.Info.MaterialStructureKind;

namespace CourseGenerator.Models.Entities.Info
{
    public class Material
    {
        public int Id { get; set; }   
        public bool IsPractical { get; set; }
        public MaterialStructure MaterialStructureCode { get; set; }
        public string Note { get; set; }

        public ICollection<MaterialCompetency> MaterialCompetencies { get; set; }
        public ICollection<HeadingMaterial> HeadingMaterials { get; set; }
        public ICollection<MaterialLang> MaterialLangs { get; set; }
        public ICollection<MaterialBlock> MaterialBlocksParent { get; set; }
        public ICollection<MaterialBlock> MaterialBlocksChild { get; set; }
        public ICollection<MaterialDependency> BaseMaterialDependencies { get; set; }
        public ICollection<MaterialDependency> MaterialDependencies { get; set; }
        public ICollection<CourseMaterial> CourseMaterials { get; set; }
        public ICollection<Theme> Themes { get; set; }
        public ICollection<UserMaterial> UserMaterials { get; set; }
        public ICollection<UserMaterialResult> UserMaterialResults { get; set; }
        public ICollection<UserMaterialMessage> UserMaterialMessages { get; set; }
        public ICollection<MaterialOrganizationForm> MaterialOrganizationForms { get; set; }
        public ICollection<MaterialConductingMethod> MaterialConductingMethods { get; set; }

        public Material()
        {
            MaterialCompetencies = new List<MaterialCompetency>();
            HeadingMaterials = new List<HeadingMaterial>();
            MaterialLangs = new List<MaterialLang>();
            MaterialBlocksParent = new List<MaterialBlock>();
            MaterialBlocksChild = new List<MaterialBlock>();
            MaterialDependencies = new List<MaterialDependency>();
            BaseMaterialDependencies = new List<MaterialDependency>();
            CourseMaterials = new List<CourseMaterial>();
            Themes = new List<Theme>();
            UserMaterials = new List<UserMaterial>();
            UserMaterialResults = new List<UserMaterialResult>();
            UserMaterialMessages = new List<UserMaterialMessage>();
            MaterialOrganizationForms = new List<MaterialOrganizationForm>();
            MaterialConductingMethods = new List<MaterialConductingMethod>();
        }
    }
}
