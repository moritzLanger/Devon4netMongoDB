using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class Dish
    {

        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonElement("_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        [BsonElement("Price")]
        [BsonRepresentation(BsonType.Decimal128)]
        public decimal Price { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [BsonElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Image
        /// </summary>
        [BsonElement("Image")]
        public Image Image { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        [BsonElement("Category")]
        public ICollection<Category> Category { get; set; }
    }
}