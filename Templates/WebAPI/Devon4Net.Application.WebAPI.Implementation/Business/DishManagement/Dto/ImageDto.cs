
namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto
{

    public class ImageDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public string mimeType { get; set; }
        public string extension { get; set; }
        public int contentType { get; set; }
        public int modificationCounter { get; set; }
    }
}