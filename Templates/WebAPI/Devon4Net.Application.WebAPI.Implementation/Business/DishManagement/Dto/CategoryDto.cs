using System.Collections.Generic;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto
{
public class CategoryDto
    {
        public string id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int showOrder { get; set; }

        public int modificationCounter { get; set; }

    }
}

