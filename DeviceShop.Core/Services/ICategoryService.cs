using DeviceShop.Core.Entities;
using System.Collections.Generic;

namespace DeviceShop.Core.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDto> GetCategories();
    }
}
