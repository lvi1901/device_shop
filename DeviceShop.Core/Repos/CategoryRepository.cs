using System.Collections.Generic;
using AutoMapper;
using DeviceShop.Core.Entities;
using DeviceShop.Core.Infrastructure;

namespace DeviceShop.Core.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IEnumerable<CategoryDto> categories;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;

            categories = Mapper.Map<IEnumerable<CategoryDto>>(appDbContext.Categories);
        }

        public IEnumerable<CategoryDto> GetAll() =>
            categories;
    }
}
