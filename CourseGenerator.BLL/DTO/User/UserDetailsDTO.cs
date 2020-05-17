using System;

namespace CourseGenerator.BLL.DTO
{
    public class UserDetailsDTO
    {
        /// <summary>
        /// Ідентифікатор.
        /// </summary>
        public string Id { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ім'я.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Прізвище.
        /// </summary>
        public string LastName { get; set; }
        
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Дата народження.
        /// </summary>
        public DateTime? BirthDate { get; set; }
    }
}
