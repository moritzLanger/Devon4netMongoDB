using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Devon4Net.Test.xUnit.Test.Integration;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service;
using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;
using FluentAssertions;

namespace Devon4Net.Test.xUnit.Test.UnitTest.Management.Controllers
{
    public class DishServiceTests : UnitTest
    {
        private readonly Mock<IDishRepository> repositoryStub = new();
        private readonly Random rand = new();
        [Fact]
        public async Task DishGetAll_WithWorkingRepo_ReturnsAllDishes()
        {
            //Arrange
            var expectedDishes = new[] { CreateRandomDish(), CreateRandomDish(), CreateRandomDish() };
            repositoryStub.Setup(repo => repo.GetAll())
                .ReturnsAsync(expectedDishes);

            var controller = new DishService(repositoryStub.Object);
            //Act
            var actualDishes = await controller.GetDish();
            //Assert
            actualDishes.Should().BeEquivalentTo(expectedDishes, options => options.ComparingByMembers<Dish>());
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
