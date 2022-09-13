using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class Category
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Description")]
        public string Description { get; set; }

        [BsonElement("ShowOrder")]
        public int ShowOrder { get; set; }

        [BsonElement("ModificationCounter")]
        public int ModificationCounter { get; set; }

    }

}
