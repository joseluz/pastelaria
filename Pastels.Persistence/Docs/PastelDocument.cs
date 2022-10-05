using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;

namespace Pastels.Persistence.Docs
{
    public class PastelDocument : IDocument
    {
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId MongoId { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }
        public string? Flavor { get; set; }
        public string? Ingredients { get; set; }
        public bool IsSweet { get; set; }
    }
}