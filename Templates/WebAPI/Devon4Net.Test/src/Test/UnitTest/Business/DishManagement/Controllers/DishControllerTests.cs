using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using Devon4Net.Test.xUnit.Test.Integration;
using Devon4Net.Application.WebAPI.Implementation.Business.DishManagement.Service;
using System.Threading.Tasks;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;

namespace Devon4Net.Test.xUnit.Test.UnitTest.Management.Controllers
{
    public class DishControllerTests : UnitTest
    {
        [Fact]
        public async Task DishSearch_WithBlankFilter_ReturnsAllDishes()
        {
            //Arrange
            var repositoryStub = new Mock<IDishRepository>();
            repositoryStub.Setup(repo => repo.GetAll());

            var controller = new DishService(repositoryStub.Object);
            //Act

            //Assert
        }
    }
}
