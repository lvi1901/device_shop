using System;
using System.Collections.Generic;

namespace DeviceShop.Core.Entities
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<DeviceDto> Devices { get; set; }
    }
}
