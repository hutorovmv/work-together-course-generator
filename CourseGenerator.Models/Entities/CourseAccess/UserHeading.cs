using CourseGenerator.Models.Entities.Info;
using CourseGenerator.Models.Entities.Identity;

namespace CourseGenerator.Models.Entities.CourseAccess
{
    /// <summary>
    /// Таблиця, що визначає загальну тематику, яка цікавить користувача
    /// </summary>
    public class UserHeading
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public int HeadingId { get; set; }
        public Heading Heading { get; set; }

        public int LevelNumber { get; set; }
        public Level Level { get; set; }

        public string Note { get; set; }


    }
}
