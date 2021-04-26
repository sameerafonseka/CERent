using CERent.Core.Lib.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Order.Lib.Domain.Entities
{
    public class OrderItems : BaseDomainModel
    {
        public int EquipmentId { get; set; }

        public int EquipmentName { get; set; }

        public decimal Price { get; set; }

        public Order Order { get; set; }
    }
}
