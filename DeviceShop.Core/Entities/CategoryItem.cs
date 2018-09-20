using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DeviceShop.Core.Entities
{
    internal class CategoryItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("CategoryId")]
        public List<DeviceItem> Devices { get; set; }
    }
}
