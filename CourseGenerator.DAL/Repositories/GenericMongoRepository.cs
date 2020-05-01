using CourseGenerator.DAL.Context;
using CourseGenerator.DAL.Interfaces;
using CourseGenerator.Models.Entities.Content;
using CourseGenerator.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CourseGenerator.DAL.Repositories
{
    public class GenericMongoRepository<T> : IMongoRepository<T> where T : class, IEntity
    {
        protected readonly MongoContext _context;
        protected readonly MongoCollection<T> _collection;


        public GenericMongoRepository(MongoContext context)
        {
            _context = context;
            _collection = _context.GetDataBase().GetCollection<T>(typeof(T).Name.ToLower());
        }

        private IQueryable<T> CreateSet() => _collection.AsQueryable<T>();

        public T Insert(T item)
        {
            try
            {
                item.Id = ObjectId.GenerateNewId();
                _collection.Insert<T>(item);
                return item;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T item)
        {
            try
            {
                var query = Query<T>.EQ(o => o.Id, item.Id);
                var update = Update<T>.Replace(item);
                _collection.Update(query, update);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(ObjectId id)
        {
            try
            {
                _collection.Remove(Query<T>.EQ<ObjectId>(p => p.Id, id));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public T GetById(ObjectId id) => _collection.FindOneById(id);
       


        public IEnumerable<T> GetAll()
        {
             return _collection.AsQueryable().AsEnumerable();
        }
    }
}
