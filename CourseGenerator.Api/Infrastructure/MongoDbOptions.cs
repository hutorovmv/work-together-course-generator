namespace CourseGenerator.Api.Infrastructure
{
    /// <summary>
    /// Налаштування підключення до документальної бази даних
    /// </summary>
    public class MongoDbOptions
    {
        /// <summary>
        /// Рядок підключення для MongoDb
        /// </summary>
        public string DbUrl { get; set; }

        /// <summary>
        /// Назва використовуваної бази даних
        /// </summary>
        public string DbName { get; set; }
    }
}
