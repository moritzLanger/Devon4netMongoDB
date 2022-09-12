using Devon4Net.Infrastructure.Logger.Logging;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Bson;
using System.Text.RegularExpressions;

namespace Devon4Net.Application.WebAPI.Implementation.Data.Repositories
{
    public class DishRepository : IDishRepository
    {
        private readonly IMongoClient _mongoClient;

        private readonly IMongoCollection<Dish> _dishCollection;

        public DishRepository()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");

            _mongoClient = new MongoClient(settings);

            var camelCaseConvention = new ConventionPack {
                new CamelCaseElementNameConvention()
                };

            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);

            _dishCollection = _mongoClient.GetDatabase("mts_progress").GetCollection<Dish>("Dish");

        }
        /*
        public async Task<Dish> GetDishById(string id)
        {
            Devon4NetLogger.Debug($"GetDishByID method from repository Dishservice with value : {id}");
            var filter_id = Builders<Dish>.Filter.Eq("id", ObjectId.Parse(id));
            var entity = _dishCollection.Find(filter_id)
                .FirstOrDefault();
            return entity;
        }
        */

        public async Task<IList<Dish>> GetAll()
        {
            var dishes = await _dishCollection
            .Find(Builders<Dish>.Filter.Empty)
            .ToListAsync();
            return dishes;
        }

        public async Task<IList<Dish>> GetDishesByCategory(IList<string> categoryIdList)
        {
            return await _dishCollection
                .Find(Builders<Dish>.Filter.In("Category.CategoryId", categoryIdList))
                .ToListAsync();
        }

        public async Task<IList<Dish>> GetDishesByPrice(decimal maxPrice)
        {
            return await _dishCollection
                .Find(Builders<Dish>.Filter.Lte("Price", maxPrice))
                .ToListAsync();
        }

        public async Task<IList<Dish>> GetDishesByLikes(int minLikes)
        {
            return await _dishCollection
                .Find(Builders<Dish>.Filter.Gte("Price", minLikes))
                .ToListAsync();
        }

        public async Task<IList<Dish>> GetDishesByString(string searchBy)
        {
            var query = new BsonRegularExpression(new Regex(searchBy, RegexOptions.IgnoreCase));
            return await _dishCollection
                .Find(Builders<Dish>.Filter.Regex("Name", query))
                .ToListAsync();
        }
        
        
        public async Task<IList<Dish>> GetDishesMatchingCriteria(decimal maxPrice, int minLikes, string searchBy, IList<string> categoryIdList)
        {
            IList<Dish> result = await GetAll();

            if(categoryIdList.Any())
            {
               
                IList<Dish> temp = await GetDishesByCategory(categoryIdList);
                var tempIds = temp.Select(tempDish => tempDish._id);
                result = result.Where(item => tempIds.Contains(item._id)).ToList();

            }

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                IList<Dish> temp = await GetDishesByString(searchBy);
                var tempNames = temp.Select(tempDish => tempDish.Name);
                result = result.Where(item => tempNames.Contains(item.Name)).ToList();

                //var query = new BsonRegularExpression(new Regex(searchBy, RegexOptions.IgnoreCase));
                //result = (IList<Dish>)result.Where(result => result.Name == query);
            }

            if (maxPrice > 0)
            {
                IList<Dish> temp = await GetDishesByPrice(maxPrice);
                var tempPrices = temp.Select(tempDish => tempDish.Price);
                result = result.Where(item => tempPrices.Contains(item.Price)).ToList();
                //result = (IList<Dish>)result.Where(result => result.Price <= maxPrice);
            }

            if (minLikes > 0)
            {
                //result = result.Where(result => result.MinLikes >= minLikes);
            }

            return result.ToList();
        }
        
    }
}