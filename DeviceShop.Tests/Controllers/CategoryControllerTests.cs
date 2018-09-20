using Microsoft.AspNetCore.Mvc;
using Xunit;
using System;
using DeviceShop.Web.Controllers;
using DeviceShop.Web.ViewModels;

namespace DeviceShop.Tests.Controllers
{
    public class CategoryControllerTests
    {
        [Fact]
        public void Index_Returns_View_Model()
        {
            var categoryController = new CategoryController();
            var categoryId = Guid.NewGuid();

            var result = categoryController.Index(categoryId);

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsType<DevicesViewComponentModel>(viewResult.Model);

            Assert.Equal($"GetDevicesByCategory?categoryId={categoryId}", model.RequestUrl);
        }
    }
}
