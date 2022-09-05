using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    public class Dish

    { 

    [BsonId]

        [BsonRepresentation(BsonType.ObjectId)]

        public long _id { get; set; }
 

    [BsonElement("Name")]

        public string Name { get; set; }



        [BsonElement("Price")]

        public decimal Price { get; set; }


        [BsonElement("Description")]

        public string Description { get; set; }



        [BsonElement("Image")]
        public ImageNosql Image { get; set; }



        [BsonElement("Category")]

        public ICollection<CategoryNosql> Category { get; set; }
    }
}