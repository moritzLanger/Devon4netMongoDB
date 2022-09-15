using System;
using System.Collections.Generic;
using Xunit;
using Moq;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using System.Linq;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Controllers;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Dto;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Converters;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;

namespace Devon4Net.Test.xUnit.Test.UnitTest.Management.Controllers
{
    public class DishControllerTests : UnitTest
    {
        private readonly Random rand = new();
        [Fact]
        public async Task DishSearch_WithGivenFilterCriteria_ReturnsAllCorrespondingDishes()
        {
            //Arrange
            var randomPrice = (decimal)rand.NextDouble();
            var minLikes = rand.Next();
            var searchBy = Guid.NewGuid().ToString();
            var Dishes = new[] { CreateRandomDish(), CreateRandomDish(), CreateRandomDish() };
            var ExpectedCategories = new[] { Dishes[0].Category, Dishes[1].Category };
            IList<Dish> ExpectedDishes = new List<Dish> { Dishes[0], Dishes[1] };
            IList<string> categoryObjIds = new List<string>() { ExpectedCategories[0].FirstOrDefault().Id, ExpectedCategories[1].FirstOrDefault().Id };
            var categorySearchDtoIds = categoryObjIds.Select(c => new CategorySearchDto
            {
                Id = c,
            }).ToList().ToArray();

            var serviceStub = new Mock<IDishService>();
            serviceStub.Setup(repo => repo.GetDishesMatchingCriteria(
                    It.IsAny<decimal>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<IList<string>>())).Returns(Task.FromResult(ExpectedDishes));

            var controller = new DishController(serviceStub.Object);
            //Act

            var filterDto = new FilterDtoSearchObjectDto { MaxPrice = randomPrice, SearchBy = searchBy, MinLikes = minLikes, Categories = new CategorySearchDto[] { } };
            var ExpectedResult = new ResultObjectDto<DishDtoResult> { };
            ExpectedResult.content = ExpectedDishes.Select(DishConverter.EntityToApi).ToList();
            ExpectedResult.Pagination.Total = ExpectedDishes.Count();

            var result = (ObjectResult) await controller.DishSearch(filterDto);
           
            //Assert
            var compareObj = JsonConvert.SerializeObject(ExpectedResult);
            Assert.Equal(compareObj, result.Value);
        }


        [Fact]
        public async Task DishSearch_WithNullFilterCriteria_ReturnsDefault()
        {
            //Arrange
            IList<Dish> Dishes = new List<Dish> { CreateRandomDish(), CreateRandomDish(), CreateRandomDish() };
            var ExpectedCategories = new[] { Dishes[0].Category, Dishes[1].Category, Dishes[2].Category };
            
            IList<string> categoryObjIds = new List<string>() { ExpectedCategories[0].FirstOrDefault().Id, ExpectedCategories[1].FirstOrDefault().Id, ExpectedCategories[2].FirstOrDefault().Id };
           
            var categorySearchDtoIds = categoryObjIds.Select(c => new CategorySearchDto
            {
                Id = c,
            }).ToList().ToArray();
            var randomPrice = (decimal)rand.NextDouble();
            var minLikes = rand.Next();
            var searchBy = Guid.NewGuid().ToString();
            var serviceStub = new Mock<IDishService>();

            serviceStub.Setup(repo => repo.GetDishesMatchingCriteria(
                    It.IsAny<decimal>(),
                    It.IsAny<int>(),
                    It.IsAny<string>(),
                    It.IsAny<IList<string>>())).Returns(Task.FromResult(Dishes));

            var controller = new DishController(serviceStub.Object);
            //Act

            var filterDto = new FilterDtoSearchObjectDto { MaxPrice = randomPrice, SearchBy = searchBy, MinLikes = minLikes, Categories = new CategorySearchDto[] { } };
            var ExpectedResult = new ResultObjectDto<DishDtoResult> { };
            ExpectedResult.content = Dishes.Select(DishConverter.EntityToApi).ToList();
            ExpectedResult.Pagination.Total = Dishes.Count();

            var result = (ObjectResult)await controller.DishSearch(null);

            //Assert
            var compareObj = JsonConvert.SerializeObject(ExpectedResult);
            Assert.Equal(compareObj, result.Value);
        }


        private Image CreateRandomImage()
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                Content = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                MimeType = Guid.NewGuid().ToString(),
                Extension = Guid.NewGuid().ToString(),
                ContentType = rand.Next(),
                ModificationCounter = rand.Next(),
            };
        }


        private Category CreateRandomCategory()
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Description = Guid.NewGuid().ToString(),
                ShowOrder = rand.Next(),
                ModificationCounter = rand.Next(),
            };
        }


        private Dish CreateRandomDish()
        {
            return new()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Guid.NewGuid().ToString(),
                Price = (decimal)rand.NextDouble() + 1,
                Image = CreateRandomImage(),
                Category = new[] { CreateRandomCategory(), CreateRandomCategory(), CreateRandomCategory() }
            };
        }
    }
}
