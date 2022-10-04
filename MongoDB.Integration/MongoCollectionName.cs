namespace Pastels.MongoDB.Integration
{
    public class MongoCollectionName
    {
        private readonly string value;

        public MongoCollectionName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Invalid Cosmos Connection String");
            }
            this.value = value;
        }

        public static implicit operator MongoCollectionName(string value) => new MongoCollectionName(value);
        public static implicit operator string(MongoCollectionName collectionName) => collectionName.value;
    }
}