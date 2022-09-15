using System.Linq.Expressions;
using Devon4Net.Infrastructure.Logger.Logging;
using Devon4Net.Domain.UnitOfWork.Service;
using Devon4Net.Domain.UnitOfWork.UnitOfWork;
using Devon4Net.Application.WebAPI.Implementation.Domain.Database;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;

        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task<IList<Dish>> GetDish() => await _dishRepository.GetAll();


        public async Task<IList<Dish>> GetDishesByCategory(IList<string> categories)
        {
            var dish = await _dishRepository.GetDishesByCategory(categories);
            return dish;
        }


        public async Task<IList<Dish>> GetDishesByPrice(decimal maxPrice)
        {
            return await _dishRepository.GetDishesByPrice(maxPrice);
        }


        public async Task<IList<Dish>> GetDishesByString(string searchBy)
        {
            return await _dishRepository.GetDishesByString(searchBy);
        }


        public async Task<IList<Dish>> GetDishesByLikes(int minLikes)
        {
            return await _dishRepository.GetDishesByLikes(minLikes);
        }
        

        public async Task<IList<Dish>> GetDishesMatchingCriteria(decimal maxPrice, int minLikes, string searchBy, IList<string> categoryIdList)
        {
            return await _dishRepository.GetDishesMatchingCriteria(maxPrice, minLikes, searchBy, categoryIdList);
        }
    }
}




   