using System.Linq.Expressions;
using Devon4Net.Domain.UnitOfWork.Repository;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IDishRepository{
        /*Task<IList<Dish>> GetAllNested(IList<string> nestedProperties, Expression<Func<Dish, bool>> predicate = null);
        */
        Task<IList<Dish>> GetAll();

        Task<IList<Dish>> GetDishesByCategory(IList<string> categoryIdList);

        Task<IList<Dish>> GetDishesByPrice(decimal maxPrice);

        Task<IList<Dish>> GetDishesByString(string searchBy);
        Task<IList<Dish>> GetDishesByLikes(int minLikes);
        Task<IList<Dish>> GetDishesMatchingCriteria(decimal maxPrice, int minLikes, string searchBy, IList<string> categoryIdList);
    }
}