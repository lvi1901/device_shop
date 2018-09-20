using System.Collections.Generic;
using DeviceShop.Core.Entities;
using DeviceShop.Core.Repos;

namespace DeviceShop.Core.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryDto> GetCategories() =>
            categoryRepository.GetCategories();
    }
}
