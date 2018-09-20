using DeviceShop.Core.Entities;
using DeviceShop.Core.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceShop.Core.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly ICategoryRepository categoryRepository;

        public DeviceService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public IEnumerable<DeviceDto> GetDevices() =>
            categoryRepository.GetCategories().SelectMany(c => c.Devices);

        public IEnumerable<DeviceDto> GetPopularDevices()
        {
            var popularDevices = new List<DeviceDto>();
            var categories = categoryRepository.GetCategories();

            foreach (var category in categories)
            {
                popularDevices.AddRange(category.Devices.Where(d => d.IsPopular));
            }

            return popularDevices.OrderBy(d => d.Name);
        }

        public IEnumerable<DeviceDto> GetCategoryDevices(Guid categoryId)
        {
            var category = categoryRepository.GetCategory(categoryId);

            return category.Devices.OrderBy(d => d.Name);
        }

        public DeviceDto GetDevice(Guid deviceId) =>
            GetDevices().FirstOrDefault(r => r.Id == deviceId);

        public DeviceDto GetCategoryDevice(Guid categoryId, Guid deviceId) =>
            GetCategoryDevices(categoryId).FirstOrDefault(r => r.Id == deviceId);
    }
}
