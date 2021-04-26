using CERent.Order.Lib.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CERent.Order.Lib.Application.Services
{
    public class PriceCalculatorFactory
    {
        private readonly IEnumerable<IPriceCalculator> _priceCalculators = null;

        public PriceCalculatorFactory(IEnumerable<IPriceCalculator> priceCalculators)
        {
            _priceCalculators = priceCalculators;
        }

        public IPriceCalculator GetPriceCalculator(EquipmentType equipmentType)
        {
            return _priceCalculators.FirstOrDefault(x => x.EquipmentType == equipmentType);
        }
    }
}
