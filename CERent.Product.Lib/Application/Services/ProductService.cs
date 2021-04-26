using CERent.Product.Lib.Application.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace CERent.Product.Lib.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger = null;

        public ProductService(ILogger<ProductService> logger)
        {
            _logger = logger;
        }

        public async Task<ProductViewModel> GetProducts()
        {
            var result = new ProductViewModel();



            return result;
        }
    }
}
