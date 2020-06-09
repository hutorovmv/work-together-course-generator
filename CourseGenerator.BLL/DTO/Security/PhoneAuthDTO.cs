namespace CourseGenerator.BLL.DTO.Security
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
