using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DeviceShop.Core.Entities;
using DeviceShop.Core.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Core.Repos
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IEnumerable<CategoryDto> categories;

        public CategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;

            var categoryItems = appDbContext.Categories.Include(d => d.Devices);
            categories = Mapper.Map<IEnumerable<CategoryDto>>(categoryItems);
        }

        public IEnumerable<CategoryDto> GetCategories() => categories;

        public CategoryDto GetCategory(Guid categoryId) =>
            categories.FirstOrDefault(r => r.Id == categoryId);
    }
}
