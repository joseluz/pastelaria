namespace Pastels.MongoDB.Integration
{
    public class MongoDatabaseName
    {
        private readonly string value;

        public MongoDatabaseName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException("Invalid Mongo Connection String");
            }
            this.value = value;
        }

        public static implicit operator MongoDatabaseName(string value) => new MongoDatabaseName(value);
        public static implicit operator string(MongoDatabaseName mongoDatabaseName) => mongoDatabaseName.value;
    }
}