using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Context
{
    public class MongoContext
    {
        public string ConnectionString { get; } 
        public string DbName { get; }
        
        IMongoClient _client;

        public MongoContext(string dburl, string dbname)
        {
            ConnectionString = dburl;
            DbName = dbname;
            _client = new MongoClient(ConnectionString);
        }

        public IMongoDatabase GetDataBase()
        {
            return _client.GetDatabase(DbName);
        }
        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            IMongoDatabase db = _client.GetDatabase(DbName);
            return db.GetCollection<T>(collectionName);
        }

        public void DropDataBase()
        {
            _client.DropDatabase(DbName);
        }

        public void DropCollection(string collectionName)
        {
            IMongoDatabase db = _client.GetDatabase(DbName);
            db.DropCollection(collectionName);
        }
    }
}
