using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Dto
{
    public class DishNosqlDto

    {

        /// <summary>

        /// the Id

        /// </summary>

        public long Id {get; set;}    

 

        /// <summary>

        /// the Name

        /// </summary>

        [Required]

        public string Name {get; set;}

 

        /// <summary>

        /// the Description

        /// </summary>

        [Required]

        public string Description { get; set;}
 

        /// <summary>

        /// the Price

        /// </summary>

        [Required]

        public decimal Price { get; set;}

        /// <summary>

        /// the Image

        /// </summary>

        public ImageNosql Image { get; set;}

 

        /// <summary>

        /// the Categories

        /// </summary>

        public ICollection<CategoryNosql> Category { get; set;}

}
        }
