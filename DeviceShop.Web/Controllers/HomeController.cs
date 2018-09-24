using DeviceShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceShop.Web.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewData["Title"] = "Welcome to Device Shop";
            return View(new DeviceList
            {
                PageSize = 8,
                RequestUrl = "GetPopularDevices"
            });
        }
    }
}