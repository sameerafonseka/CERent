using CERent.Product.Lib.Application.Mappers;
using CERent.Product.Lib.Application.Models;
using CERent.Product.Lib.Domain.Services;
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
        private readonly IEquipmentService _equipmentService = null;

        public ProductService(ILogger<ProductService> logger,
            IEquipmentService equipmentService)
        {
            _logger = logger;
            _equipmentService = equipmentService;
        }

        public async Task<ProductsViewModel> GetProducts()
        {
            var result = new ProductsViewModel();
            
            result.Product = (await _equipmentService.GetAll()).Map();

            return result;
        }
    }
}
