using DDona.SimpleAuth.Domain.Entities;
using DDona.SimpleAuth.Domain.Enums;
using DDona.SimpleAuth.Domain.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace DDona.SimpleAuth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _Logger;
        private readonly IUnitOfWork _UnitOfWork;

        public ProductController(ILogger<ProductController> logger, IUnitOfWork unitOfWork)
        {
            _Logger = logger;
            _UnitOfWork = unitOfWork;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var products = await _UnitOfWork.ProductRepository.GetAllProducts();
            return Ok(products);
        }
    }
}
