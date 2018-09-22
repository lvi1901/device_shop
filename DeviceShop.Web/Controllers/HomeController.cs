using DeviceShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Welcome to Device Shop";
            return View(new DevicesViewComponentModel
            {
                PageSize = 8,
                RequestUrl = "GetPopularDevices"
            });
        }
    }
}