using DeviceShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace DeviceShop.Core.Repos
{
    public interface IDeviceRepository
    {
        IEnumerable<DeviceDto> GetAll();

        DeviceDto GetById(Guid deviceId);
    }
}
