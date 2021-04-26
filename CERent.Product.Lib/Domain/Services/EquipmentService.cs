using CERent.Product.Lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CERent.Product.Lib.Domain.Services
{
    public class EquipmentService : IEquipmentService
    {
        private readonly ProductDbContext _productDbContext = null;

        public EquipmentService(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task<List<Equipment>> GetAll()
        {
            var equipments = await _productDbContext.Equipments.ToListAsync();
            return equipments;
        }
    }
}
