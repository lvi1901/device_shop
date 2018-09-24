using System;
using System.Collections.Generic;
using System.Linq;
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
        public void Index_Returns_Not_Null_View()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(It.IsAny<Guid>());

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_Returns_Correct_View_Type()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(It.IsAny<Guid>());

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Returns_Not_Null_Model()
        {
            // Arrange
            var testDevice = testDevices[0];
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetDeviceById(testDevice.Id)).Returns(testDevice);

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(testDevice.Id);

            // Assert
            Assert.NotNull(result.Model);
        }

        [Fact]
        public void Index_Returns_Correct_Model_Type()
        {
            // Arrange
            var testDevice = testDevices[0];
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetDeviceById(testDevice.Id)).Returns(testDevice);

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(testDevice.Id);

            // Assert
            Assert.IsType<DeviceDto>(result.Model);
        }

        [Fact]
        public void Index_Returns_Data()
        {
            // Arrange
            var testDevice = testDevices[0];
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetDeviceById(testDevice.Id)).Returns(testDevice);

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(testDevice.Id);
            var device = result.Model as DeviceDto;

            // Assert
            Assert.Equal("HTC", device.Name);
            Assert.Equal("$", device.Currency);
            Assert.True(device.IsPopular);
            Assert.Equal(5.01m, device.Price);
            Assert.Equal("Description for HTC", device.Description);
            Assert.Equal("http://image.url.com/1", device.ImageUrl);
        }

        [Fact]
        public void Index_View_Has_Title()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.Index(It.IsAny<Guid>());

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
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(testDevices);

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
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(testDevices);

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
        public void GetPopularDevices_Returns_Data()
        {
            // Arrange
            var deviceServiceMock = new Mock<IDeviceService>();
            deviceServiceMock.Setup(d => d.GetPopularDevices()).Returns(testDevices);

            var deviceController = new DeviceController(deviceServiceMock.Object);

            // Act
            var result = deviceController.GetPopularDevices() as OkObjectResult;
            var devices = result.Value as List<DeviceDto>;
            var firstDevice = devices.First();

            // Assert
            Assert.Equal("HTC", firstDevice.Name);
            Assert.Equal("$", firstDevice.Currency);
            Assert.True(firstDevice.IsPopular);
            Assert.Equal(5.01m, firstDevice.Price);
            Assert.Equal("Description for HTC", firstDevice.Description);
            Assert.Equal("http://image.url.com/1", firstDevice.ImageUrl);
        }
        #endregion
    }
}
