using CERent.Core.Lib.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Product.Lib.Domain.Entities
{
    public class Inventory : BaseDomainModel
    {
        public Equipment Equipment { get; set; }

        public int Quantity { get; set; }

    }
}
