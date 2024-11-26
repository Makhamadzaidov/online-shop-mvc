using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Domain.Entities;
using OnlineMarket.Service.Commons.Utils;
using OnlineMarket.Service.DTOs.Products;
using OnlineMarket.Service.Interfaces;
using System.Linq.Expressions;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("CreateProduct")]
        public async Task<IActionResult> CreateAsync(ProductCreationDto product)
        {
            return Ok(await _productService.CreateAsync(product));
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllAsync(string name = null, [FromQuery] PaginationParams @params = null)
        {
            // Build the filter expression based on the name parameter
            Expression<Func<Product, bool>> filter = null;

            if (!string.IsNullOrWhiteSpace(name))
            {
                filter = p => p.Name.Contains(name); // Filter by name if provided
            }

            var products = await _productService.GetAllAsync(filter, @params);

            return Ok(products);
        }

    }
}
