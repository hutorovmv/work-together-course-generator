using System;

namespace CourseGenerator.BLL.DTO.User
{
    /// <summary>
    /// Об'єкт для передачі налаштувань користувача
    /// </summary>
    public class UserSettingsDTO
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Ім'я
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Прізвище
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Дата народження
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Код мови користувача
        /// </summary>
        public string PreferedLangCode { get; set; }
    }
}
