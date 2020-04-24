using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseGenerator.Api.Models
{
    /// <summary>
    /// ViewModel, що представляє тему в меню вибору теми
    /// </summary>
    public class ThemeSelectModel
    {
        /// <summary>
        /// Код теми.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Локалізована назва теми.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Чи пройдена тема користувачем.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
