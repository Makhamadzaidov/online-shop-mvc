using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Service.DTOs.Products;
using OnlineMarket.Service.Interfaces;

namespace OnlineMarket.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> CreateAsync(ProductCreationDto product)
        {
            await _productService.CreateAsync(product);

            return RedirectToAction("Index");
        }*/

        /*[HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }*/

    }
}
