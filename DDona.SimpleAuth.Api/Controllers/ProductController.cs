using DDona.SimpleAuth.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DDona.SimpleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _Logger;
        private readonly IProductService _ProductService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _Logger = logger;
            _ProductService = productService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var products = await _ProductService.GetAllProducts();
            return Ok(products);
        }

        [HttpGet("with-category")]
        public async Task<IActionResult> GetAllWithCategory()
        {
            var products = await _ProductService.GetAllProductsWithCategories();
            return Ok(products);
        }
    }
}
