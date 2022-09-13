using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class Dish
    { 
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
 
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Price")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("Image")]
        public Image Image { get; set; }

        [BsonElement("Category")]
        public ICollection<Category> Category { get; set; }
    }
}