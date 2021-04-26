using CERent.Order.Lib.Application.Options;
using CERent.Order.Lib.Domain.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Order.Lib.Application.Services
{
    public class RegularPriceCalculator : IPriceCalculator
    {
        private readonly ILogger _logger = null;
        private readonly RentalFeeSetting _rentalFeeSetting = null;

        public EquipmentType EquipmentType => EquipmentType.Regular;

        public RegularPriceCalculator(
            ILogger<RegularPriceCalculator> logger,
            IOptions<RentalFeeSetting> rentalFeeSetting)
        {
            _logger = logger;
            _rentalFeeSetting = rentalFeeSetting?.Value;
        }

        public decimal Calculate(int noOfDays)
        {
            decimal price = _rentalFeeSetting.OneTime;

            if (noOfDays <= 2)
            {
                price += _rentalFeeSetting.PremiumDaily * noOfDays;
            }
            else
            {
                price += _rentalFeeSetting.PremiumDaily * 2;
                price += _rentalFeeSetting.RegularDaily * (noOfDays - 2);
            }

            return price;
        }
    }
}
