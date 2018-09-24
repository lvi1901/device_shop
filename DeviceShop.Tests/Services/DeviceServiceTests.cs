using DeviceShop.Core.Repos;
using DeviceShop.Core.Services;
using Moq;
using System.Linq;
using Xunit;

namespace DeviceShop.Tests.Services
{
    public class DeviceServiceTests : TestBase
    {
        #region GetDevices
        [Fact]
        public void GetDevices_Returns_Data()
        {
            // Arrange
            var categoryRepoMock = new Mock<IDeviceRepository>();
            categoryRepoMock.Setup(d => d.GetAll()).Returns(testDevices);

            var deviceService = new DeviceService(categoryRepoMock.Object);

            // Act
            var devices = deviceService.GetDevices();

            // Assert
            Assert.Equal(4, devices.Count());
            Assert.Equal("HTC", devices.First().Name);
        }
        #endregion

        #region GetPopularDevices
        [Fact]
        public void GetPopularDevices_Returns_Data()
        {
            // Arrange
            var categoryRepoMock = new Mock<IDeviceRepository>();
            categoryRepoMock.Setup(d => d.GetAll()).Returns(testDevices);

            var deviceService = new DeviceService(categoryRepoMock.Object);

            // Act
            var devices = deviceService.GetPopularDevices();

            // Assert
            Assert.Equal(2, devices.Count());
            Assert.Equal("HTC", devices.First().Name);
        }

        [Fact]
        public void GetPopularDevices_Returns_Only_Popular_Data()
        {
            // Arrange
            var categoryRepoMock = new Mock<IDeviceRepository>();
            categoryRepoMock.Setup(d => d.GetAll()).Returns(testDevices);

            var deviceService = new DeviceService(categoryRepoMock.Object);

            // Act
            var devices = deviceService.GetPopularDevices().ToList();

            // Assert
            Assert.Equal(2, devices.Count);
            Assert.True(devices[0].IsPopular);
            Assert.True(devices[1].IsPopular);
        }

        [Fact]
        public void GetPopularDevices_Returns_Orderable_Data()
        {
            // Arrange
            var categoryRepoMock = new Mock<IDeviceRepository>();
            categoryRepoMock.Setup(d => d.GetAll()).Returns(testDevices.OrderByDescending(d => d.Name));

            var deviceService = new DeviceService(categoryRepoMock.Object);

            // Act
            var devices = deviceService.GetPopularDevices().ToList();

            // Assert
            Assert.Equal(2, devices.Count);
            Assert.Equal("HTC", devices[0].Name);
            Assert.Equal("Samsung Galaxy", devices[1].Name);
        }
        #endregion

        #region GetDevicesByCategoryId
        [Fact]
        public void GetDevicesByCategoryId_Returns_Data()
        {
            // Arrange
            var categoryRepoMock = new Mock<IDeviceRepository>();
            categoryRepoMock.Setup(d => d.GetAll()).Returns(testDevices);

            var deviceService = new DeviceService(categoryRepoMock.Object);

            // Act
            var devices = deviceService.GetDevicesByCategoryId(testCategories[0].Id);

            // Assert
            Assert.Equal(2, devices.Count());
            Assert.Equal("HTC", devices.First().Name);
        }

        [Fact]
        public void GetDevicesByCategoryId_Returns_Orderable_Data()
        {
            // Arrange
            var categoryRepoMock = new Mock<IDeviceRepository>();
            categoryRepoMock.Setup(d => d.GetAll()).Returns(testDevices.OrderByDescending(d => d.Name));

            var deviceService = new DeviceService(categoryRepoMock.Object);

            // Act
            var devices = deviceService.GetDevicesByCategoryId(testCategories[0].Id).ToList();

            // Assert
            Assert.Equal(2, devices.Count);
            Assert.Equal("HTC", devices[0].Name);
            Assert.Equal("Samsung Galaxy", devices[1].Name);
        }
        #endregion

        #region GetDeviceById
        [Fact]
        public void GetDeviceById_Returns_Data()
        {
            // Arrange
            var testDevice = testDevices[0];
            var categoryRepoMock = new Mock<IDeviceRepository>();
            categoryRepoMock.Setup(d => d.GetById(testDevice.Id)).Returns(testDevice);

            var deviceService = new DeviceService(categoryRepoMock.Object);

            // Act
            var device = deviceService.GetDeviceById(testDevice.Id);

            // Assert
            Assert.Equal("HTC", device.Name);
        }
        #endregion
    }
}
