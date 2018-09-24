using DeviceShop.Core.Repos;
using DeviceShop.Core.Services;
using Moq;
using System.Linq;
using Xunit;

namespace DeviceShop.Tests.Services
{
    public class CategoryServiceTests : TestBase
    {
        [Fact]
        public void GetCategories_Returns_Data()
        {
            // Arrange
            var categoryRepoMock = new Mock<ICategoryRepository>();
            categoryRepoMock.Setup(c => c.GetAll()).Returns(testCategories);

            var categoryService = new CategoryService(categoryRepoMock.Object);

            // Act
            var categories = categoryService.GetCategories();

            // Assert
            Assert.Equal(3, categories.Count());
            Assert.Equal("Smartphones", categories.First().Name);
        }
    }
}
