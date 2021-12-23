using Microsoft.AspNetCore.Mvc;
using Skinet.Model.Models;
using Skinet.Core.Entities;
using Skinet.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skinet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productsService;

        public ProductsController(IProductService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsService.GetAllProducts();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
        {
            var product = await _productsService.GetProduct(id);

            return product;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _productsService.GetProductBrands();

            return Ok(productBrands);
        }
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            var productTypes = await _productsService.GetProductTypes();

            return Ok(productTypes);
        }
    }
}
