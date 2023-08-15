using MongoDB.Bson.Serialization.Attributes;

namespace ProductWebAPI.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.Decimal128)]
        public decimal ProductPrice { get; set; }
        public int ProductStock { get; set; }
        public string ProductDescripiton { get; set; }
        public string ProductImage { get; set; }
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string CategoryId { get; set; }
        [BsonIgnore]
        public Category Category { get; set; }
    }
}