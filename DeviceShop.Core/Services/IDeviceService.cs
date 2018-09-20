using DeviceShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace DeviceShop.Core.Services
{
    public interface IDeviceService
    {
        IEnumerable<DeviceDto> GetDevices();

        DeviceDto GetDevice(Guid deviceId);

        DeviceDto GetCategoryDevice(Guid categoryId, Guid deviceId);

        IEnumerable<DeviceDto> GetPopularDevices();

        IEnumerable<DeviceDto> GetCategoryDevices(Guid categoryId);
    }
}
