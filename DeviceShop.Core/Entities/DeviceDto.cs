﻿using System;

namespace DeviceShop.Core.Entities
{
    public class DeviceDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public string Currency { get; set; }

        public bool IsPopular { get; set; }

        public Guid CategoryId { get; set; }
    }
}
