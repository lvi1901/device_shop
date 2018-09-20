using DeviceShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace DeviceShop.Core.Repos
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetCategories();

        CategoryDto GetCategory(Guid categoryId);
    }
}
