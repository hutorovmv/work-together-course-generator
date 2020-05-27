namespace CourseGenerator.Api.Infrastructure
{
    /// <summary>
    /// Об'єкт, що відправляється користувачу
    /// після успішної аутентифікації
    /// </summary>
    public class AuthResponse
    {
        /// <summary>
        /// JWT токен для аутентифікації
        /// </summary>
        public string access_token { get; set; }

        /// <summary>
        /// Ідентифікатор користувача
        /// </summary>
        public string userId { get; set; }

        /// <summary>
        /// Ім'я користувача
        /// </summary>
        public string userName { get; set; }

        /// <summary>
        /// Ім'я
        /// </summary>
        public string firstName { get; set; }

        /// <summary>
        /// Прізвище
        /// </summary>
        public string lastName { get; set; }

        /// <summary>
        /// Код мови, зручної користувачу
        /// </summary>
        public string langCode { get; set; }
    }
}
