using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.BLL.DTO
{
    public class CourseSelectDTO
    {
        /// <summary>
        /// Код курсу.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Локалізована назва курсу.
        /// </summary>
        public int Name { get; set; }
    }
}
