using System;
using System.Linq;
using DeviceShop.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeviceShop.Web.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceService deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            this.deviceService = deviceService;
        }

        public ViewResult Index(Guid deviceId)
        {
            var device = deviceService.GetDeviceById(deviceId);

            ViewData["Title"] = "Device";
            return View(device);
        }

        public IActionResult GetPopularDevices()
        {
            var popularDevices = deviceService.GetPopularDevices();

            if (popularDevices.Count() == 0)
            {
                return NotFound();
            }
            return Ok(popularDevices);
        }

        public IActionResult GetDevicesByCategory(Guid categoryId)
        {
            var categoryDevices = deviceService.GetDevicesByCategoryId(categoryId);

            if (categoryDevices.Count() == 0)
            {
                return NotFound(categoryId);
            }
            return Ok(categoryDevices);
        }
    }
}