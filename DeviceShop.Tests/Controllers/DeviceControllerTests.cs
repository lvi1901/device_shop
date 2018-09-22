using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeviceShop.Core.Entities;
using DeviceShop.Core.Services;
using DeviceShop.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DeviceShop.Tests.Controllers
{
    public class DeviceControllerTests : TestBase
    {
        #region Index
        [Fact]
        public void Index_View_Returns_View_Not_Null()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(testDevices.First().Id);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_View_Returns_View_Type()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(testDevices.First().Id);

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_View_Returns_Model_Not_Null()
        {
            // Arrange
            var deviceId = ConvertToGuid(1);
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetDevice(deviceId)).Returns(testDevices.Find(d => d.Id == deviceId));

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(testDevices.First().Id);

            // Assert
            Assert.NotNull(result.Model);
        }

        [Fact]
        public void Index_View_Returns_Model_Type()
        {
            // Arrange
            var deviceId = ConvertToGuid(1);
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetDevice(deviceId)).Returns(testDevices.Find(d => d.Id == deviceId));

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(testDevices.First().Id);

            // Assert
            Assert.IsType<DeviceDto>(result.Model);
        }

        [Fact]
        public void Index_View_Returns_Data()
        {
            // Arrange
            var deviceId = ConvertToGuid(1);
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetDevice(deviceId)).Returns(testDevices.Find(d => d.Id == deviceId));

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(deviceId);
            var device = result.Model as DeviceDto;

            // Assert
            Assert.Equal(deviceId, device.Id);
            Assert.Equal("Device 1", device.Name);
            Assert.Equal("$", device.Currency);
            Assert.True(device.IsPopular);
            Assert.Equal(5.01m, device.Price);
            Assert.Equal("Description for Device 1", device.Description);
            Assert.Equal("http://image.url.com/1", device.ImageUrl);
        }

        [Fact]
        public void Index_View_Has_Title()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(testDevices.First().Id);

            // Assert
            Assert.Equal("Device", result.ViewData["Title"]);
        }
        #endregion

        #region GetPopularDevices
        [Fact]
        public void GetPopularDevices_Returns_Not_Null()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.GetPopularDevices();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetPopularDevices_Returns_Ok_Data_Type()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(testDevices.Where(d => d.IsPopular));

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.GetPopularDevices();

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void GetPopularDevices_Returns_Ok_Status()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(testDevices.Where(d => d.IsPopular));

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.GetPopularDevices() as OkObjectResult;

            // Assert
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void GetPopularDevices_Returns_NotFound_Data_Type()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(new List<DeviceDto>());

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.GetPopularDevices();

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void GetPopularDevices_Returns_NotFound_Status()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(new List<DeviceDto>());

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.GetPopularDevices() as NotFoundResult;

            // Assert
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public void GetPopularDevices_Returns_Data_Count()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(testDevices.Where(d => d.IsPopular));

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.GetPopularDevices() as OkObjectResult;
            var devices = result.Value as IEnumerable<DeviceDto>;

            // Assert
            Assert.Equal(2, devices.Count());
        }

        [Fact]
        public void GetPopularDevices_Returns_Data()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(testDevices.Where(d => d.IsPopular));

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.GetPopularDevices() as OkObjectResult;
            var devices = result.Value as IEnumerable<DeviceDto>;
            var firstDevice = devices.First();

            // Assert
            Assert.Equal(ConvertToGuid(1), firstDevice.Id);
            Assert.Equal("Device 1", firstDevice.Name);
            Assert.Equal("$", firstDevice.Currency);
            Assert.True(firstDevice.IsPopular);
            Assert.Equal(5.01m, firstDevice.Price);
            Assert.Equal("Description for Device 1", firstDevice.Description);
            Assert.Equal("http://image.url.com/1", firstDevice.ImageUrl);
        }
        #endregion
    }
}
