namespace CourseGenerator.BLL.DTO
{
    public class CodeAuthDTO
    {
        /// <summary>
        /// Id користувача.
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// Унікальний код для аутентифікації.
        /// </summary>
        public string Code { get; set; }
    }
}
