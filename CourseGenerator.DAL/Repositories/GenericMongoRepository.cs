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
using System.Threading.Tasks;

namespace CourseGenerator.DAL.Repositories
{
    public class GenericMongoRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly MongoContext _context;
        protected readonly IMongoCollection<T> _collection;

        public GenericMongoRepository(MongoContext context)
        {
            _context = context;
            _collection = _context.GetDataBase().GetCollection<T>(typeof(T).Name.ToLower());
        }

        private IQueryable<T> CreateSet() => _collection.AsQueryable<T>();

        public async Task CreateAsync(T item)
        {
            try
            {
                await _collection.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void Update(T item)
        {
            try
            {
                var expression = new ExpressionFilterDefinition<T>(d => d.Id == item.Id);
                await _collection.ReplaceOneAsync(expression, item);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async void Delete(T item)
        {
            try
            {
                var expression = new ExpressionFilterDefinition<T>(d => d.Id == item.Id);
                await _collection.DeleteOneAsync(expression);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<T> GetAsync(params object[] key)
        {
            ObjectId? id = null;
            if (key != null)
                id = (ObjectId)key.First();

            if (id == null)
                throw new Exception("ObjectId cannot be null");

            var expression = new ExpressionFilterDefinition<T>(d => d.Id == id);
            var cursor = await _collection.FindAsync(expression);
            return await cursor.FirstOrDefaultAsync();
        }
       


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _collection.AsQueryable().ToListAsync();
        }

        public void Dispose() { }
    }
}
