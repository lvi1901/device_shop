using DeviceShop.Core.Entities;
using DeviceShop.Core.Repos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeviceShop.Core.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly IDeviceRepository deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        public IEnumerable<DeviceDto> GetDevices() =>
            deviceRepository.GetAll();

        public IEnumerable<DeviceDto> GetPopularDevices()
        {
            var popularDevices = GetDevices().Where(d => d.IsPopular);

            return popularDevices.OrderBy(d => d.Name);
        }

        public IEnumerable<DeviceDto> GetDevicesByCategoryId(Guid categoryId)
        {
            var categoryDevices = GetDevices().Where(d => d.CategoryId == categoryId);

            return categoryDevices.OrderBy(d => d.Name);
        }

        public DeviceDto GetDeviceById(Guid deviceId) =>
            deviceRepository.GetById(deviceId);
    }
}
