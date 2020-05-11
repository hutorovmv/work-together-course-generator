using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class MaterialManager
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        public bool IsOwner { get; set; }
        public string Note { get; set; }
    }
}
