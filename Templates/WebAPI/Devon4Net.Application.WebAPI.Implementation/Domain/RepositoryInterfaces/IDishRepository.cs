using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IDishRepository
    {
        /// <summary>
        /// Return all Dish entities saved in our collection.
        /// </summary>
        /// <returns>An IList of type Dish</returns>
        Task<IList<Dish>> GetAll();


        /// <summary>
        /// Return all Dishes matching the category id's given as an argument
        /// </summary>
        /// <param name="categoryIdList">List of string category id's</param>
        /// <returns>An IList of type Dish matching the filter criteria</returns>
        Task<IList<Dish>> GetDishesByCategory(IList<string> categoryIdList);


        /// <summary>
        /// Return all Dishes which prices are less or equal to given maxPrice
        /// </summary>
        /// <param name="maxPrice">Max Price to filter given as a decimal</param>
        /// <returns>An IList of type Dish matching the filter criteria</returns>
        Task<IList<Dish>> GetDishesByPrice(decimal maxPrice);


        /// <summary>
        /// Return all Dishes which name include the content of searchBy
        /// </summary>
        /// <param name="searchBy">A string to search for in Dish names</param>
        /// <returns>An IList of type Dish matching the filter criteria</returns>
        Task<IList<Dish>> GetDishesByString(string searchBy);


        /// <summary>
        /// Return all Dishes which have at least minLikes likes.
        /// </summary>
        /// <param name="minLikes">Integer of minimum likes to filter for</param>
        /// <returns>An IList of type Dish matching the filter criteria</returns>
        Task<IList<Dish>> GetDishesByLikes(int minLikes);


        /// <summary>
        /// Return all Dishes which cost maximum @maxPrice, have at least @minLikes, contain the string @searchBy in their name and are categorized by @categoryIdList 
        /// </summary>
        /// <param name="maxPrice">Decimal maximum price to filter dishes for</param>
        /// <param name="minLikes">Integer of minimum likes to filter dishes for</param>
        /// <param name="searchBy">String to filter Dish names for</param>
        /// <param name="categoryIdList">List of string category id's to filter dishes for</param>
        /// <returns>An IList of type Dish matching the filter criteria</returns>
        Task<IList<Dish>> GetDishesMatchingCriteria(decimal maxPrice, int minLikes, string searchBy, IList<string> categoryIdList);
    }
}