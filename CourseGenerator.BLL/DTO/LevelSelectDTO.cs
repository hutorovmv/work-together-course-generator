using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.BLL.DTO
{
    public class LevelSelectDTO
    {
        /// <summary>
        /// Номер рівня.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Локалізована назва рівня.
        /// </summary>
        public string Name { get; set; }
    }
}
