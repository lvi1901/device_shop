using AutoMapper;
using DeviceShop.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeviceShop.Core.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        internal DbSet<CategoryItem> Categories { get; set; }

        internal DbSet<DeviceItem> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            Mapper.Initialize(cfg => {
                cfg.CreateMap<CategoryItem, CategoryDto>();
                cfg.CreateMap<DeviceItem, CategoryDto>();
            });
        }
    }
}
