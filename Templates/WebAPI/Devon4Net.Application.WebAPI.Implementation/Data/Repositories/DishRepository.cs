using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Infrastructure.Logger.Logging;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;
using Devon4Net.Infrastructure.Logger.Logging;
using Newtonsoft.Json;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Conventions;

namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly IMongoClient _mongoClient;

        private readonly IMongoCollection<Dish> _dishNosqlCollection;
        private IMongoCollection<Dish> _dishCollection;


        public DishRepository()
        {



            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");

            _mongoClient = new MongoClient(settings);



            var camelCaseConvention = new ConventionPack {
                new CamelCaseElementNameConvention()
                };

            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);



            _dishNosqlCollection = _mongoClient.GetDatabase("My-Thai-Star").GetCollection<Dish>("Dish");


        }
/*
        public Task<Dish> GetDishById(long id)
        {
            Devon4NetLogger.Debug($"GetDishByID method from repository Dishservice with value : {id}");

            return GetFirstOrDefault(t => t._id == id);
        }

*/
        public async Task<IList<Dish>> GetAll()
        {

            var dishes = await _dishNosqlCollection

            .Find(Builders<Dish>.Filter.Empty)

            .ToListAsync();



            return dishes;

        }

/*        public async Task<IList<Dish>> GetAllNested(IList<string> nestedProperties, Expression<Func<Dish, bool>> predicate = null)
        {
            return await Get(nestedProperties, predicate);
        }*/
    }
}