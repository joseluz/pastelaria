using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Pastels.Persistence.DataStores;
using Pastels.Persistence.Docs;

namespace Pastels.MongoDB.Integration
{
    public abstract class BasicDataSource<T> : AbstractMongoDataStore, IDataStore<T> where T : IDocument
    {
        private readonly MongoCollectionName collectionName;
        private readonly IIdGenerator idGenerator;

        public BasicDataSource(MongoClient mongoClient,
                               MongoDatabaseName databaseName,
                               MongoCollectionName collectionName,
                               IIdGenerator idGenerator)
            : base(mongoClient, databaseName)
        {
            this.collectionName = collectionName;
            this.idGenerator = idGenerator;
        }

        protected IMongoCollection<T> GetCollection()
        {
            return GetDatabase().GetCollection<T>(collectionName);
        }

        public virtual async Task<IList<T>> FindAll()
        {
            return await GetCollection().AsQueryable().ToListAsync();
        }

        public virtual async Task<T> Create(T item)
        {
            var id = (ObjectId)idGenerator.GenerateId(databaseName, collectionName);
            var document = item.ToBsonDocument();
            item.Id = id.ToString();
            document["_id"] = id;
            document["Id"] = id.ToString();

            await mongoClient.GetDatabase(databaseName).GetCollection<BsonDocument>(collectionName).InsertOneAsync(document);

            return item;
        }

        public virtual async Task<T?> Update(T item)
        {
            var filter = Builders<T>.Filter.Eq("_id", new ObjectId(item.Id));
            var result = await GetCollection().ReplaceOneAsync(filter, item);
            if (result.MatchedCount == 0)
            {
                return default;
            }
            return item;
        }

        public virtual async Task Delete(T item)
        {
            if (item.Id != null)
            {
                var filter = Builders<T>.Filter.Eq("_id", new ObjectId(item.Id));
                await GetCollection().DeleteOneAsync(filter);
            }
        }
    }
}