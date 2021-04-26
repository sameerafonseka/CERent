using CERent.Core.Lib.Domain.Model;
using CERent.Order.Lib.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Order.Lib.Domain.Entities
{
    public class RentalFee : BaseDomainModel
    {
        public RentalFeeType Type { get; set; }

        public decimal Fee { get; set; }
    }
}
