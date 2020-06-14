using MongoDB.Driver;

namespace CourseGenerator.DAL.Context
{
    public class MongoContext
    {
        public string ConnectionString { get; } 
        public string DbName { get; }
        
        IMongoClient _client;

        public MongoContext(string dbUrl)
        {
            ConnectionString = dbUrl;            
            _client = new MongoClient(ConnectionString);
            var connection = new MongoUrlBuilder(dbUrl);
            DbName = connection.DatabaseName;
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

        public void DropDatabase()
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
