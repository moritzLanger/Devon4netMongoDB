using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class Category
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
        /// Description
        /// </summary>
        [BsonElement("Description")]
        public string Description { get; set; }

        /// <summary>
        /// ShowOrder
        /// </summary>
        [BsonElement("ShowOrder")]
        public int ShowOrder { get; set; }

        /// <summary>
        /// ModificationCounter
        /// </summary>
        [BsonElement("ModificationCounter")]
        public int ModificationCounter { get; set; }

    }

}
