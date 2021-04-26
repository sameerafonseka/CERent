using CERent.Product.Lib.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CERent.Product.Lib.Domain.Services
{
    public interface IEquipmentService
    {
        Task<List<Equipment>> GetAll();
    }
}