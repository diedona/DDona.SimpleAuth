using DDona.SimpleAuth.Domain.Entities;
using DDona.SimpleAuth.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DDona.SimpleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _Logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _Logger = logger;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            _Logger.LogInformation("Ok - starting get all...");
            return Ok(new List<Product>() { new Product("Orange", ProductUnitEnum.Kilograms, 1.25m) });
        }
    }
}
