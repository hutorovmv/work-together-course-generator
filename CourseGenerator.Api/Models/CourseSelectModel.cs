using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє курс в меню вибору курсу
    /// </summary>
    public class CourseSelectModel
    {
        /// <summary>
        /// Код курсу.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Локалізована назва курсу.
        /// </summary>
        public string Name { get; set; }
    }
}
