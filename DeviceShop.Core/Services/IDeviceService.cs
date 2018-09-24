using DeviceShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace DeviceShop.Core.Services
{
    public interface IDeviceService
    {
        IEnumerable<DeviceDto> GetDevices();

        DeviceDto GetDeviceById(Guid deviceId);

        IEnumerable<DeviceDto> GetPopularDevices();

        IEnumerable<DeviceDto> GetDevicesByCategoryId(Guid categoryId);
    }
}
