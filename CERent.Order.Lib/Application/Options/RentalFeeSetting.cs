using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Order.Lib.Application.Options
{
    public sealed class RentalFeeSetting
    {
        public decimal OneTime { get; set; }

        public decimal PremiumDaily { get; set; }

        public decimal RegularDaily { get; set; }
    }
}
