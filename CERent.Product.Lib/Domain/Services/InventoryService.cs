using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Product.Lib.Domain.Services
{
    public class InventoryService : IInventoryService
    {
        ILogger<InventoryService> _logger = null;
        private readonly ProductDbContext _productDbContext = null;

        public InventoryService(
            ILogger<InventoryService> logger,
            ProductDbContext productDbContext
            )
        {
            _logger = logger;
            _productDbContext = productDbContext;
        }

        public async Task IncraseQuantity(int equipmentId, int noOfItems)
        {
            if (noOfItems <= 0)
                throw new ArgumentException("No of items can not be 0 or less");

            await ChangeQuantity(equipmentId, noOfItems);
        }

        public async Task DecreaseQuantity(int equipmentId, int noOfItems)
        {
            if (noOfItems <= 0)
                throw new ArgumentException("No of items can not be 0 or less");

            await ChangeQuantity(equipmentId, -noOfItems);
        }

        private async Task ChangeQuantity(int equipmentId, int delta)
        {
            var equipment = _productDbContext.Equipments.FirstOrDefault(x => x.Id == equipmentId);

            if (equipment == null)
                throw new Exception("Equipments not found");

            var eqQuantity = _productDbContext.Inventory.FirstOrDefault(x => x.Equipment.Id == equipmentId);

            if (eqQuantity == null)
            {
                eqQuantity = new Entities.Inventory
                {
                    Equipment = new Entities.Equipment { Id = equipmentId },
                    Quantity = delta
                };

                _productDbContext.Inventory.Add(eqQuantity);
            }
            else
            {
                eqQuantity.Quantity += delta;
            }

            await _productDbContext.SaveChangesAsync();
        }
    }
}
