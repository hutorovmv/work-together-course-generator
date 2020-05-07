using MongoDB.Bson;
using System.Collections.Generic;

namespace CourseGenerator.DAL.Interfaces
{
    public interface IMongoRepository<T> where T : class
    {
        
        T Insert(T item);

        void Update(T item);

        void Delete(ObjectId id);

        T GetById(ObjectId id);

        IEnumerable<T> GetAll();
    }
}
