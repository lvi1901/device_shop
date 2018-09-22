using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceShop.Core.Services;
using DeviceShop.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DeviceShop.Tests.Controllers
{
    public class DeviceControllerTests
    {
        [Fact]
        public void Index_View_Returns_ViewResult_Not_Null()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(Guid.NewGuid());

            // Assert
            Assert.NotNull(result);
        }

        //[Fact]
        //public void Index_View_Returns_ViewModel_Data()
        //{
        //    // Arrange
        //    var homeController = new HomeController();

        //    // Act
        //    var result = homeController.Index();
        //    var deviceViewModel = result.Model as DevicesViewComponentModel;

        //    // Assert
        //    Assert.Equal(8, deviceViewModel.PageSize);
        //    Assert.Equal("GetPopularDevices", deviceViewModel.RequestUrl);
        //}

        //[Fact]
        //public void TestMethod2()
        //{
        //    //var mock = new Mock<ICategoryRepository>();

        //    //var device = new DeviceController(mock.Object);

        //    //var result = device.Index(Guid.NewGuid());

        //    //var viewResult = Assert.IsType<ViewResult>(result);
        //    //var model = Assert.IsAssignableFrom<List<DeviceItem>>(viewResult.ViewData.Model);

        //    //Assert.Equal(2, model.Count());


        //    var mock = new Mock<ICategoryRepository>();
        //    mock.Setup(p => p.).Returns("Jignesh");
        //    HomeController home = new HomeController(mock.Object);
        //    string result = home.GetNameById(1);
        //    Assert.AreEqual("Jignesh", result);
        //}

        //private List<DeviceItem> GetDevices()
        //{
        //    var devices = new List<DeviceItem>
        //    {
        //        new DeviceItem
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Test 1"
        //        },
        //        new DeviceItem
        //        {
        //            Id = Guid.NewGuid(),
        //            Name = "Test 2"
        //        }
        //    };

        //    return devices;
        //}
    }
}
