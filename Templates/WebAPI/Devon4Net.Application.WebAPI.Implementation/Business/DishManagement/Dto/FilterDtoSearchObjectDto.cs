using Newtonsoft.Json;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto
{
    public class FilterDtoSearchObjectDto
    {
        [JsonProperty(PropertyName = "categories")]
        public CategorySearchDto[] Categories { get; set; }

        [JsonProperty(PropertyName = "searchBy")]
        public string SearchBy { get; set; }

        [JsonProperty(PropertyName = "maxPrice")]
        public Decimal? MaxPrice { get; set; }

        [JsonProperty(PropertyName = "minLikes")]
        public Int32? MinLikes { get; set; }

        public void Deconstruct(out CategorySearchDto[] categories, out string searchBy, out Decimal maxPrice, out Int32 minLikes)
        {
            categories = Categories ?? new CategorySearchDto[]{};
            searchBy = SearchBy ?? String.Empty;
            maxPrice = MaxPrice.GetValueOrDefault(0);
            minLikes = Convert.ToInt32(MinLikes.GetValueOrDefault(0));
        }
    }
}
