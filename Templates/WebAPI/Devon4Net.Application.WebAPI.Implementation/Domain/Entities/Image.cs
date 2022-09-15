using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class Image
    {
        /// <summary>
        /// Id
        /// </summary>
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        [BsonElement("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Content
        /// </summary>
        [BsonElement("Content")]
        public string Content { get; set; }

        /// <summary>
        /// MimeType
        /// </summary>
        [BsonElement("MimeType")]
        public string MimeType { get; set; }

        /// <summary>
        /// Extension
        /// </summary>
        [BsonElement("Extension")]
        public string Extension { get; set; }

        /// <summary>
        /// ContentType
        /// </summary>
        [BsonElement("ContentType")]
        public int ContentType { get; set; }

        /// <summary>
        /// ModificationCounter
        /// </summary>
        [BsonElement("ModificationCounter")]
        public int ModificationCounter { get; set; }
    }
}
