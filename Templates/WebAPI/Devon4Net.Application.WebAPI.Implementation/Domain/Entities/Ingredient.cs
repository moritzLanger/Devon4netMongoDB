using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.Entities
{
    [Owned]
    public partial class Ingredient
    {
        public Ingredient()
        {
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal? Price { get; set; }
    }
}
