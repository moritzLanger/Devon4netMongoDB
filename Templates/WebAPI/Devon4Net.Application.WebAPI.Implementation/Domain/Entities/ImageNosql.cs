using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class ImageNosql
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id { get; set; }
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
