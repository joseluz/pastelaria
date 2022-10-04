namespace Pastels.MongoDB.Integration
{
    public class MongoConnectionString
    {
        private readonly string value;

        public MongoConnectionString(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Invalid Mongo Connection String");
            }
            this.value = value;
        }

        public static implicit operator MongoConnectionString(string value) => new MongoConnectionString(value);
        public static implicit operator string(MongoConnectionString connectionString) => connectionString.value;
    }
}