using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DeviceShop.Core.Services;
using DeviceShop.Web.ViewModels;

namespace DeviceShop.Web.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = categoryService.GetCategories();

            return View(await GetListAsync(categories));
        }

        private Task<List<T>> GetListAsync<T>(IEnumerable<T> list) =>
            Task.Run(() => list.ToList());
    }
}
