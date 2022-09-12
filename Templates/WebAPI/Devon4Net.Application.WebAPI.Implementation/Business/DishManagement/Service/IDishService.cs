using System.Linq.Expressions;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service
{
    /// <summary>
    /// TodoService interface
    /// </summary>
    public interface IDishService
    {
        Task<IList<Dish>> GetDish();

        Task<IList<Dish>> GetDishesByCategory(IList<string> categoryIdList);

        Task<IList<Dish>> GetDishesByPrice(decimal maxPrice);

        Task<IList<Dish>> GetDishesByString(string searchBy);
        Task<IList<Dish>> GetDishesByLikes(int minLikes);
        Task<IList<Dish>> GetDishesMatchingCriteria(decimal maxPrice, int minLikes, string searchBy, IList<string> categoryIdList);
    }
}
