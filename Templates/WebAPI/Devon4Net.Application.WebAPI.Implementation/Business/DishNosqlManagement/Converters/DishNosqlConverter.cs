using Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Converters
{
    public class DishNosqlConverter

    {



        /// <summary>

        /// ModelToDto transformation

        /// </summary>

        /// <param name="item"></param>

        /// <returns></returns>

        public static DishNosqlDto ModelToDto(Dish item)

        {

            if (item == null) return new DishNosqlDto();



            return new DishNosqlDto
            {
                Id = item._id,

                Name = item.Name,

                Description = item.Description,

                Price = item.Price,

                Image = item.Image,

                Category = item.Category

            };

        } 
    } 
}
