using DeviceShop.Core.Entities;
using System.Collections.Generic;

namespace DeviceShop.Core.Repos
{
    public interface ICategoryRepository
    {
        IEnumerable<CategoryDto> GetAll();
    }
}
