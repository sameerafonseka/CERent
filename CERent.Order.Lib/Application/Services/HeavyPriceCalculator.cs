using CERent.Order.Lib.Application.Options;
using CERent.Order.Lib.Domain.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CERent.Order.Lib.Application.Services
{
    public class HeavyPriceCalculator : IPriceCalculator
    {
        private readonly ILogger _logger = null;
        private readonly RentalFeeSetting _rentalFeeSetting = null;

        public HeavyPriceCalculator(
            ILogger<HeavyPriceCalculator> logger,
            IOptions<RentalFeeSetting> rentalFeeSetting)
        {
            _logger = logger;
            _rentalFeeSetting = rentalFeeSetting?.Value;
        }

        public EquipmentType EquipmentType => EquipmentType.Heavy;

        public decimal Calculate(int noOfDays)
        {
            decimal price = (_rentalFeeSetting.OneTime) + (_rentalFeeSetting.PremiumDaily * noOfDays);
            return price;
        }
    }
}
