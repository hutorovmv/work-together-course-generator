namespace CourseGenerator.BLL.DTO
{
    public class ThemeSelectDTO
    {
        /// <summary>
        /// Код теми.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Локалізована назва теми.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Чи пройдена тема користувачем.
        /// </summary>
        public bool IsCompleted { get; set; }
    }
}
