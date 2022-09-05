using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class DishNosqlRepository : IDishNosqlRepository

    { 

        private readonly IMongoClient _mongoClient;

        private readonly IMongoCollection<Dish> _dishNosqlCollection;



        public DishNosqlRepository()
        {

           

            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");

            _mongoClient = new MongoClient(settings);



            var camelCaseConvention = new ConventionPack { 
                new CamelCaseElementNameConvention()
                };

            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);



            _dishNosqlCollection = _mongoClient.GetDatabase("My-Thai-Star").GetCollection<Dish>("Dish");


        }


        public async Task<List<Dish>> GetAll() { 

            var dishes = await _dishNosqlCollection

                .Find(Builders<Dish>.Filter.Empty)

                .ToListAsync();

 

            return dishes;

            }
        }
}
                
