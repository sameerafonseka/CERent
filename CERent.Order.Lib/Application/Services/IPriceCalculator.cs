using CERent.Order.Lib.Domain.Enums;

namespace CERent.Order.Lib.Application.Services
{
    public interface IPriceCalculator
    {
        EquipmentType EquipmentType { get; }

        decimal Calculate(int noOfDays);
    }
}