using CERent.Core.Lib.Api;
using CERent.Product.Lib.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CERent.Product.Api.Controllers
{
    [ApiController]
    [ApiVersion("1")]
    [Route("/api/v{version:apiVersion}/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger = null;
        private readonly IProductService _productService = null;

        public ProductController(ILogger<ProductController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        [Route("")]
        public async Task<JsonResponse> GetProducts()
        {
            try
            {
                var result = await _productService.GetProducts();
                return JsonResponse.Success(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return JsonResponse.Error(ex.Message);
            }
        }
    }
}
