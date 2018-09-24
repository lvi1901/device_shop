using Microsoft.AspNetCore.Mvc;
using Xunit;
using DeviceShop.Web.Controllers;
using DeviceShop.Web.ViewModels;
using System;
using Moq;

namespace DeviceShop.Tests.Controllers
{
    public class CategoryControllerTests
    {
        [Fact]
        public void Index_Returns_Not_Null_View()
        {
            // Arrange
            var categoryController = new CategoryController();

            // Act
            var result = categoryController.Index(It.IsAny<Guid>());

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Index_Returns_Correct_View_Type()
        {
            // Arrange
            var categoryController = new CategoryController();

            // Act
            var result = categoryController.Index(It.IsAny<Guid>());

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Index_Returns_Not_Null_Model()
        {
            // Arrange
            var categoryController = new CategoryController();

            // Act
            var result = categoryController.Index(It.IsAny<Guid>());

            // Assert
            Assert.NotNull(result.Model);
        }

        [Fact]
        public void Index_Returns_Correct_Model_Type()
        {
            // Arrange
            var categoryController = new CategoryController();

            // Act
            var result = categoryController.Index(It.IsAny<Guid>());

            // Assert
            Assert.IsType<DeviceList>(result.Model);
        }

        [Fact]
        public void Index_Returns_Data()
        {
            // Arrange
            var categoryController = new CategoryController();

            // Act
            var categoryId = It.IsAny<Guid>();
            var result = categoryController.Index(categoryId);
            var deviceViewModel = result.Model as DeviceList;

            // Assert
            Assert.Equal(12, deviceViewModel.PageSize);
            Assert.Equal($"GetDevicesByCategory?categoryId={categoryId}", deviceViewModel.RequestUrl);
        }

        [Fact]
        public void Index_Has_Title()
        {
            // Arrange
            var categoryController = new CategoryController();

            // Act
            var result = categoryController.Index(It.IsAny<Guid>());

            // Assert
            Assert.Equal("Category", result.ViewData["Title"]);
        }
    }
}
