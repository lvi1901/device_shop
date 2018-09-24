using Microsoft.AspNetCore.Mvc;
using DeviceShop.Web.Controllers;
using DeviceShop.Web.ViewModels;
using Xunit;

namespace DeviceShop.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_Not_Null_View()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_Returns_Correct_View_Type()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Returns_Not_Null_Model()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result.Model);
        }

        [Fact]
        public void Index_Returns_Correct_Model_Type()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.IsType<DeviceList>(result.Model);
        }

        [Fact]
        public void Index_Returns_Data()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();
            var deviceViewModel = result.Model as DeviceList;

            // Assert
            Assert.Equal(8, deviceViewModel.PageSize);
            Assert.Equal("GetPopularDevices", deviceViewModel.RequestUrl);
        }

        [Fact]
        public void Index_Has_Title()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.Equal("Welcome to Device Shop", result.ViewData["Title"]);
        }
    }
}
