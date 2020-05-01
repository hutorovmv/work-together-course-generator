using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseGenerator.DAL.Context
{
    public class MongoContext
    {
        string _connectionString;
        string _mongoDbName;
        MongoClient _client;

        public MongoContext(string dburl, string dbname)
        {
            _connectionString = dburl;
            _mongoDbName = dbname;
            _client = new MongoClient(_connectionString);
        }

        public MongoDatabase GetDataBase()
        {
            return _client.GetServer().GetDatabase(_mongoDbName);
        }

        public void DropDataBase(string dbName)
        {
            var server = _client.GetServer();
            server.DropDatabase(dbName);
        }

        public void DropCollection(string collectionName)
        {
            var database = GetDataBase();

            if (database.CollectionExists(collectionName))
            {
                database.DropCollection(collectionName);
            }
        }



    }
}
