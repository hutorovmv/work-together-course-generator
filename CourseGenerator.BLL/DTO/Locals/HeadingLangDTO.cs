namespace CourseGenerator.BLL.DTO.Locals
{
    /// <summary>
    /// Об'єкт для передачі локалізованої частини
    /// сутності - Рубрика
    /// </summary>
    public class HeadingLangDTO
    {
        /// <summary>
        /// Локалізована назва рубрики
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Локалізований опис рубрики
        /// </summary>
        public string Description { get; set; }
    }
}
