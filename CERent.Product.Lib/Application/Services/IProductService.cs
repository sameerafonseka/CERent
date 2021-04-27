using CERent.Product.Lib.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CERent.Product.Lib.Application.Services
{
    public interface IProductService
    {
        Task<IList<ProductDto>> GetProducts();
    }
}