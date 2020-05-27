using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    /// <summary>
    /// Таблиця, що визначає порядок мов, матеріали якими пропонуються
    /// користувачеві, якщо відсутній матеріал вибраною мовою
    /// </summary>
    public class UserLanguagePriority
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public string LangCode { get; set; }
        public Language Language { get; set; }
        
        /// <summary>
        ///Пріорітетність конкретної мови 
        /// </summary>
        public int Priority { get; set; }

        public string Note { get; set; }
    }
}
