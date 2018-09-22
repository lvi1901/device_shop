using Microsoft.AspNetCore.Mvc;
using DeviceShop.Web.Controllers;
using DeviceShop.Web.ViewModels;
using Xunit;

namespace DeviceShop.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_View_Returns_ViewResult_Not_Null()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_View_Returns_ViewResult_Type()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_View_Returns_View_Data_Not_Null()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.NotNull(result.Model);
        }

        [Fact]
        public void Index_View_Returns_View_Data_Type()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            Assert.IsType<DevicesViewComponentModel>(result.Model);
        }

        [Fact]
        public void Index_View_Returns_View_Data()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();
            var deviceViewModel = result.Model as DevicesViewComponentModel;

            // Assert
            Assert.Equal(8, deviceViewModel.PageSize);
            Assert.Equal("GetPopularDevices", deviceViewModel.RequestUrl);
        }

        [Fact]
        public void Index_View_Has_Title()
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
