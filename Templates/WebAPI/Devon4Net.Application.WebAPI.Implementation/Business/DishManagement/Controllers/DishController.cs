using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Converters;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class DishController : ControllerBase
    {
        private readonly IDishService _DishService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="DishService"></param>
        public DishController(IDishService DishService)
        {
            _DishService = DishService;
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(typeof(DishDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("/mythaistar/services/rest/dishmanagement/v1/dish/search")]
        public async Task<IActionResult> DishSearch([FromBody] FilterDtoSearchObjectDto filterDto)
        {
            if (filterDto == null)
            {
                filterDto = new FilterDtoSearchObjectDto { MaxPrice = 0, SearchBy = string.Empty, MinLikes = 0, Categories = new CategorySearchDto[]{} };
            }

            // I guess this was one of the more recent changes in the frontend.
            // Most queries with numbers are now actually parsed in json as numbers

            // converts and destructures the given filter-dto
            // also converts or defaults values if necessary
            
            var (
                categories,
                searchBy,
                maxPrice,
                minLikes
            ) = filterDto;

            var categoryIds = categories.Select(c => c.Id).ToList();

            var dishQueryResult = await _DishService.GetDish();

            var result = new ResultObjectDto<DishDtoResult> {};

            result.content = dishQueryResult.Select(DishConverter.EntityToApi).ToList();
            result.Pagination.Total = dishQueryResult.Count();

            return new ObjectResult(JsonConvert.SerializeObject(result));
        }
    }
}
