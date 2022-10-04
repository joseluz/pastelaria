using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Pastels.Persistence.DataStores;
using Pastels.Persistence.Docs;

namespace MongoDB.Integration
{
    public class PastelDataStore : BasicDataSource<PastelDocument>, IPastelDataStore
    {
        public PastelDataStore(MongoClient mongoClient, MongoDatabaseName databaseName, IIdGenerator idGenerator)
               : base(mongoClient, databaseName, "Pastel", idGenerator) { }
    }
}