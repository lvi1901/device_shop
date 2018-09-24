using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using DeviceShop.Core.Entities;
using DeviceShop.Core.Infrastructure;

namespace DeviceShop.Core.Repos
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IEnumerable<DeviceDto> devices;

        public DeviceRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;

            devices = Mapper.Map<IEnumerable<DeviceDto>>(appDbContext.Devices);
        }

        public IEnumerable<DeviceDto> GetAll() =>
            devices;

        public DeviceDto GetById(Guid id) =>
            devices.FirstOrDefault(r => r.Id == id);
    }
}
