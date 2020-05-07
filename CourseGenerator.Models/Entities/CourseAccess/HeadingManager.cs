using CourseGenerator.Models.Entities.Identity;
using CourseGenerator.Models.Entities.Info;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    /// <summary>
    /// Таблиця, що показує власника рубрики із правом редагування
    /// </summary>
    public class HeadingManager
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int HeadingId { get; set; }
        public Heading Heading { get; set; }

        public bool IsOwner { get; set; }

        public string Note { get; set; }


    }
}
