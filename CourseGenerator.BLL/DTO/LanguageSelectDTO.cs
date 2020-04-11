using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.BLL.DTO
{
    public class LanguageSelectDTO
    {
        /// <summary>
        /// Код мови.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Назва мовою оригіналу.
        /// </summary>
        public string Name { get; set; }
    }
}
