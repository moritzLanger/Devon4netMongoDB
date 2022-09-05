using System;
using System.Collections.Generic;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Converters
{
public class DishConverter
    {
        /// <summary>
        /// Transforms entity object to Dto object
        /// </summary>
        /// <param name="item">Entity item to be transformed to api Dto</param>
        /// <returns>API Dto</returns>
        public static DishDtoResult EntityToApi(Dish item)
        {
            if (item == null) return null;

            return new DishDtoResult
            {
                dish = DishToApi(item),

                image = GetImageDtoFromImage(item.Image),
                categories = GetCategories(item.Category),
            };

        }
        /*
                private static List<ExtraDto> GetDishExtras(ICollection<DishIngredient> itemDishIngredient)
                {
                    var result = new List<ExtraDto>();

                    if (itemDishIngredient == null) return result;

                    try
                    {
                        foreach (var item in itemDishIngredient)
                        {
                            result.Add(new ExtraDto
                            {
                                id = item.IdIngredient,
                                description = item.IdIngredientNavigation.Description,
                                price = item.IdIngredientNavigation.Price,
                                modificationCounter = item.ModificationCounter,
                                revision = 1,
                                name = item.IdIngredientNavigation.Name
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        var msg = $"{ex.Message} : {ex.InnerException}";
                    }

                    return result;
                }*/

        private static List<CategoryDto> GetCategories(ICollection<CategoryNosql> itemDishCategory)
        {
            var result = new List<CategoryDto>();

            if (itemDishCategory == null) return result;

            try
            {
                foreach (var item in itemDishCategory)
                {
                    result.Add(new CategoryDto
                    {
                        id = item.Id,
                        description = item.Description,
                        modificationCounter = item.ModificationCounter,
                        name = item.Name,
                        showOrder = item.ShowOrder
                    });

                }
            }
            catch (Exception ex)
            {
                var msg = $"{ex.Message} : {ex.InnerException}";
            }

            return result;
        }

        private static DishDto DishToApi(Dish item)
        {
            return new DishDto
            {
                id = item._id,
                description = item.Description,
                name = item.Name,
                price = item.Price
            };
        }

        private static ImageDto GetImageDtoFromImage(ImageNosql image)
        {
            if (image == null) return new ImageDto();
            var result = new ImageDto();

            try
            {
                result = new ImageDto
                {
                    content = image.Content,
                    modificationCounter = image.ModificationCounter,
                    mimeType = image.MimeType,
                    name = image.Name,
                    id = image.Id,
                    contentType = image.ContentType,
                    extension = image.Extension
                };
            }
            catch (Exception ex)
            {
                var msg = $"{ex.Message} : {ex.InnerException}";
            }


            return result;
        }
    }
}
