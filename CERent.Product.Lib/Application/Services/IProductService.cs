using CERent.Product.Lib.Application.Models;
using System.Threading.Tasks;

namespace CERent.Product.Lib.Application.Services
{
    public interface IProductService
    {
        Task<ProductsViewModel> GetProducts();
    }
}