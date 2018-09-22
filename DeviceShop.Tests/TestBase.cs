using DeviceShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace DeviceShop.Tests
{
    public class TestBase
    {
        protected readonly List<DeviceDto> testDevices;

        protected TestBase()
        {
            testDevices = new List<DeviceDto>
            {
                new DeviceDto
                {
                    Id = ConvertToGuid(1),
                    Name = "Device 1",
                    Currency = "$",
                    IsPopular = true,
                    Price = 5.01m,
                    Description = "Description for Device 1",
                    ImageUrl = "http://image.url.com/1"
                },
                new DeviceDto
                {
                    Id = ConvertToGuid(2),
                    Name = "Device 2",
                    Currency = "$",
                    Price = 11,
                    Description = "Description for Device 2",
                    ImageUrl = "http://image.url.com/2"
                },
                new DeviceDto
                {
                    Id = ConvertToGuid(3),
                    Name = "Device 3",
                    Currency = "$",
                    Price = 7.1m,
                    Description = "Description for Device 3",
                    ImageUrl = "http://image.url.com/3"
                },
                new DeviceDto
                {
                    Id = ConvertToGuid(4),
                    Name = "Device 4",
                    Currency = "$",
                    IsPopular = true,
                    Price = 7.1m,
                    Description = "Description for Device 4",
                    ImageUrl = "http://image.url.com/4"
                }
            };
        }

        protected readonly static Guid Id = Guid.NewGuid();

        protected Guid ConvertToGuid(int id)
        {
            var bytes = new byte[16];
            BitConverter.GetBytes(id).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
