using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using System;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    public class UserMaterialResult
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int MaterialId { get; set; }
        public Material Material { get; set; }

        /// <summary>
        /// Посилання на результат 
        /// </summary>
        public string Url { get; set; }
        public DateTime DateTime { get; set; }
        public string Note { get; set; }

    }
}
