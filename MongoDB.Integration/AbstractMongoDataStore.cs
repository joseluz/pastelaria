using MongoDB.Driver;

namespace MongoDB.Integration
{
    abstract public class AbstractMongoDataStore
    {
        protected MongoClient mongoClient;
        protected MongoDatabaseName databaseName;

        public AbstractMongoDataStore(MongoClient mongoClient, MongoDatabaseName databaseName)
        {
            this.mongoClient = mongoClient;
            this.databaseName = databaseName;
        }

        protected IMongoDatabase GetDatabase()
        {
            return mongoClient.GetDatabase(databaseName);
        }
    }
}