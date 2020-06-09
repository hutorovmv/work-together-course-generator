namespace CourseGenerator.BLL.DTO.Entities
{
    /// <summary>
    /// Об'єкт для передачі нелокалізованої частини
    /// сутності - Рубрика.
    /// </summary>
    public class HeadingDTO
    {
        /// <summary>
        /// Ідентифікатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Код для побудови ієрархії
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Код в універсальному десятковому класифікаторі
        /// </summary>
        public string UDC { get; set; }

        /// <summary>
        /// Примітка (для авторів контенту)
        /// </summary>
        public string Note { get; set; }
    }
}
