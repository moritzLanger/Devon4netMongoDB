using System;
using Xunit;
using Moq;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;

namespace Devon4Net.Test.xUnit.Test.UnitTest.Management.Controllers
{
    public class DishServiceTests : UnitTest
    {
        private readonly Mock<IDishRepository> repositoryStub = new();
        private readonly Random rand = new();
        [Fact]
        public async Task GetDish_WithPopulatedRepo_ReturnsAllDishes()
        {
            //Arrange
            var ExpectedDishes = new[] { CreateRandomDish(), CreateRandomDish(), CreateRandomDish() };
            repositoryStub.Setup(repo => repo.GetAll())
                .ReturnsAsync(ExpectedDishes);

            var controller = new DishService(repositoryStub.Object);
            //Act
            var actualDishes = await controller.GetDish();
            //Assert
            actualDishes.Should().BeEquivalentTo(ExpectedDishes, options => options.ComparingByMembers<Dish>());
        }


        [Fact]
        public async Task GetDishesByCategory_WithGivenCategories_ReturnsTheCorrespondingCategoryDishes()
        {
            //Arrange
            var Dishes = new[] { CreateRandomDish(), CreateRandomDish(), CreateRandomDish() };
            var ExpectedCategories = new[] { Dishes[0].Category, Dishes[1].Category };
            IList<Dish> ExpectedDishes = new List<Dish> { Dishes[0], Dishes[1] };
            IList<string> Ids = new List<string>() { ExpectedCategories[0].FirstOrDefault().Id, ExpectedCategories[1].FirstOrDefault().Id };

            var controller = new DishService(repositoryStub.Object);

            repositoryStub.Setup(repo => repo.GetDishesByCategory(Ids))
                .ReturnsAsync(ExpectedDishes);
            //Act
            var result = await controller.GetDishesByCategory(Ids);
            //Assert
            result.Should().BeEquivalentTo(ExpectedDishes, options => options.ComparingByMembers<Dish>());
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
                Category = new[] { CreateRandomCategory(), CreateRandomCategory() , CreateRandomCategory() }
            };
        }
    }
}
