using DeviceShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Welcome to Device Shop";
            return View(new DevicesViewComponentModel
            {
                PageSize = 12,
                RequestUrl = "GetPopularDevices"
            });
        }
    }
}