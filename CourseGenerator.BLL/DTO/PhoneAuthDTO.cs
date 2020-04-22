using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.BLL.DTO
{
    public class PhoneAuthDTO
    {
        /// <summary>
        /// Номер телефону користувача.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Код підтвердження.
        /// </summary>
        public string Code { get; set; }
    }
}
