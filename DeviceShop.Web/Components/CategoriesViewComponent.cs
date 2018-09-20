using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DeviceShop.Core.Services;

namespace DeviceShop.Web.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync() =>
            View(await GetListAsync(categoryService.GetCategories()));

        private Task<List<T>> GetListAsync<T>(IEnumerable<T> list) =>
            Task.Run(() => list.ToList());
    }
}
