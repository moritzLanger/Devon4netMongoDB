using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class Image
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Content")]
        public string Content { get; set; }
        [BsonElement("MimeType")]
        public string MimeType { get; set; }
        [BsonElement("Extension")]
        public string Extension { get; set; }
        [BsonElement("ContentType")]
        public int ContentType { get; set; }
        [BsonElement("ModificationCounter")]
        public int ModificationCounter { get; set; }
    }
}
