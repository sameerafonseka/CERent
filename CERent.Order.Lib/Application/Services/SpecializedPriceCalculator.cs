using CERent.Order.Lib.Application.Options;
using CERent.Order.Lib.Domain.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Order.Lib.Application.Services
{
    public class SpecializedPriceCalculator : IPriceCalculator
    {
        private readonly ILogger _logger = null;
        private readonly RentalFeeSetting _rentalFeeSetting = null;

        public EquipmentType EquipmentType => EquipmentType.Specialized;

        public SpecializedPriceCalculator(
            ILogger<SpecializedPriceCalculator> logger,
            IOptions<RentalFeeSetting> rentalFeeSetting)
        {
            _logger = logger;
            _rentalFeeSetting = rentalFeeSetting?.Value;
        }

        public decimal Calculate(int noOfDays)
        {
            decimal price = 0;
            
            if(noOfDays <= 3)
            {
                price = _rentalFeeSetting.PremiumDaily * noOfDays;
            }
            else
            {
                price = (_rentalFeeSetting.PremiumDaily * 3) + (_rentalFeeSetting.RegularDaily * (noOfDays - 3));
            }
            
            return price;
        }
    }
}
