using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Interfaces
{
    /// <summary>
    /// Інтерфейс, який реалізується классами, що містять ієрархію об'єктів
    /// </summary>
    /// <typeparam name="TId">Тип властивості, на основі якої формується ієрархія</typeparam>
    /// <typeparam name="TEntity">Тип сутності, що реалізує інтерфейс</typeparam>
    public interface IHierarchyLocal<TId, TEntity> where TEntity : class
    {
        /// <summary>
        /// Метод, що дозволяє отримати найвищуланку ієрархії, яка не має 
        /// парентів, вказаною мовою
        /// </summary>
        /// <returns>Колекцію об'єктів, що не містять парентів</returns>
        Task<IEnumerable<TEntity>> GetRootLocalAsync(string langCode);

        /// <summary>
        /// Метод, що знаходить об'єкти вище за ієрархією заданою мовою
        /// </summary>
        /// <param name="id">Властивість, на якій формується ієрархія</param>
        /// <param name="langCode">Код мови, якою повертаються об'єкти</param>
        /// <returns>Колекцію об'єктів, на рівень вище від прийнятого</returns>
        Task<TEntity> GetParentsLocalAsync(TId id, string langCode);

        /// <summary>
        /// Метод, що знаходить об'єкти нижче за ієрархією заданою мовою
        /// </summary>
        /// <param name="id">Властивість, на якій формується ієрархія</param>
        /// <param name="langCode">Код мови, якою повертаються об'єкти</param>
        /// <returns>Колекцію об'єктів, на рівень нижче від прийнятого</returns>
        Task<IEnumerable<TEntity>> GetChildrenLocalAsync(TId id, string langCode);
    }
}
