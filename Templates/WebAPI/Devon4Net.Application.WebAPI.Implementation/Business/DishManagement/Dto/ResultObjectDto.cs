using Newtonsoft.Json;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto
{
    public class ResultObjectDto<T>
    {
        [JsonProperty(PropertyName = "pagination")]
        public Pagination Pagination { get; set; }

        [JsonProperty(PropertyName = "content")]
        public List<T> content { get; set; }

        public ResultObjectDto()
        {
            Pagination = new Pagination();
            content = new List<T>();
        }
    }
}