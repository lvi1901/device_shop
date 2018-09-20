using Microsoft.AspNetCore.Mvc;
using DeviceShop.Web.Controllers;
using DeviceShop.Web.ViewModels;
using Xunit;

namespace DeviceShop.Tests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Returns_View_Model()
        {
            // Arrange
            var homeController = new HomeController();

            // Act
            var result = homeController.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsType<DevicesViewComponentModel>(viewResult.Model);

            Assert.Equal("GetPopularDevices", model.RequestUrl);
        }
    }
}
