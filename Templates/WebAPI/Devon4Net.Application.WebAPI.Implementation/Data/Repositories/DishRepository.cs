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
            //Set up the connection string and create a corresponding mongoclient
            var settings = MongoClientSettings.FromConnectionString("mongodb://localhost:27017");
            _mongoClient = new MongoClient(settings);

            //Register the mongodb c# driver to map the document field names to the model entity names
            var camelCaseConvention = new ConventionPack { new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("CamelCase", camelCaseConvention, type => true);
            
            //Receive the Dish collection from our mongodatabase called mts
            _dishCollection = _mongoClient.GetDatabase("mts").GetCollection<Dish>("Dish");

        }


        public async Task<IList<Dish>> GetAll()
        {
            return await _dishCollection
            .Find(Builders<Dish>.Filter.Empty)
            .ToListAsync();
        }


        public async Task<IList<Dish>> GetDishesByCategory(IList<string> categoryIdList)
        {
            return await _dishCollection
                .Find(Builders<Dish>.Filter.In("Category._id", categoryIdList))
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
            //Return all Dishes from collection to filter for intersection with MatchingCriteria results
            IList<Dish> result = await GetAll();

            if(categoryIdList.Any())
            {
                //Return Dishes containing the given category id's
                result = result.Where(dish => dish.Category.Any(cat => categoryIdList.Contains(cat.Id))).ToList();
            }

            if (!string.IsNullOrWhiteSpace(searchBy))
            {
                //Return Dishes containing the given searchBy string in their names
                result = result.Where(dish => dish.Name.Contains(searchBy, StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            if (maxPrice > 0)
            {
                //Return Dishes which cost maximum maxPrice
                result = result.Where(dish => dish.Price <= maxPrice).ToList();
            }

            if (minLikes > 0)
            {
                //result = result.Where(dish => dish.MinLikes >= minLikes).ToList();
            }

            return result.ToList();
        } 
    }
}