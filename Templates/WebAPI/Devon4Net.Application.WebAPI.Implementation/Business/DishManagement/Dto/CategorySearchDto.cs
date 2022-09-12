using Newtonsoft.Json;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto
{
    public class CategorySearchDto
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

    }
}
