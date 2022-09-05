using Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Converters;
using Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("CorsPolicy")]
    public class DishNosqlController : Controller { 


        private readonly IDishNosqlService _dishNosqlService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dishServiceNosql"></param>
        public DishNosqlController(IDishNosqlService dishServiceNosql)

        {

            _dishNosqlService = dishServiceNosql;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<DishNosqlDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Route("/mythaistar/services/rest/dishmanagement/v2/dish")]

        public async Task<List<DishNosqlDto>> Get()
        {
            var result = await _dishNosqlService.GetAsync();

            return result.Select(DishNosqlConverter.ModelToDto).ToList();
        } 
    }
}
