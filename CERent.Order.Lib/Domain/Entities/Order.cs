using CERent.Core.Lib.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Order.Lib.Domain.Entities
{
    public class Order : BaseDomainModel
    {
        public IList<OrderItems> OrderItems { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
