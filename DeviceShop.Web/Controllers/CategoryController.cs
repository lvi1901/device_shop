using System;
using DeviceShop.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DeviceShop.Web.Controllers
{
    public class CategoryController : Controller
    {
        public ViewResult Index(Guid categoryId)
        {
            ViewData["Title"] = "Category";
            return View(new DeviceList
            {
                PageSize = 12,
                RequestUrl = $"GetDevicesByCategory?categoryId={categoryId}"
            });
        }
    }
}