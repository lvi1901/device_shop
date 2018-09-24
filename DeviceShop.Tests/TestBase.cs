using DeviceShop.Core.Entities;
using System;
using System.Collections.Generic;

namespace DeviceShop.Tests
{
    public class TestBase
    {
        protected readonly List<CategoryDto> testCategories;
        protected readonly List<DeviceDto> testDevices;

        protected TestBase()
        {
            testCategories = new List<CategoryDto>
            {
                new CategoryDto { Id = ConvertToGuid(1), Name = "Smartphones" },
                new CategoryDto { Id = ConvertToGuid(2), Name = "Laptops" },
                new CategoryDto { Id = ConvertToGuid(3), Name = "Tablets" }
            };

            testDevices = new List<DeviceDto>
            {
                new DeviceDto
                {
                    Id = ConvertToGuid(4),
                    Name = "HTC",
                    Currency = "$",
                    IsPopular = true,
                    Price = 5.01m,
                    Description = "Description for HTC",
                    ImageUrl = "http://image.url.com/1",
                    CategoryId = testCategories[0].Id
                },
                new DeviceDto
                {
                    Id = ConvertToGuid(5),
                    Name = "Hewlett Packard",
                    Currency = "$",
                    Price = 11,
                    Description = "Description for Hewlett Packard",
                    ImageUrl = "http://image.url.com/2",
                    CategoryId = testCategories[1].Id
                },
                new DeviceDto
                {
                    Id = ConvertToGuid(6),
                    Name = "IPad",
                    Currency = "$",
                    Price = 7.1m,
                    Description = "Description for IPad",
                    ImageUrl = "http://image.url.com/3",
                    CategoryId = testCategories[2].Id
                },
                new DeviceDto
                {
                    Id = ConvertToGuid(7),
                    Name = "Samsung Galaxy",
                    Currency = "$",
                    IsPopular = true,
                    Price = 7.1m,
                    Description = "Description for Samsung Galaxy",
                    ImageUrl = "http://image.url.com/4",
                    CategoryId = testCategories[0].Id
                }
            };
        }

        protected Guid ConvertToGuid(int id)
        {
            var bytes = new byte[16];
            BitConverter.GetBytes(id).CopyTo(bytes, 0);
            return new Guid(bytes);
        }
    }
}
