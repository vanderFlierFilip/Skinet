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

        [HttpGet()]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _productsService.GetAllProducts();

            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetProduct(int id)
        {
            var product = await _productsService.GetProduct(id);

            if (product == null)
                return NotFound();

            return product;
        }
        [HttpGet("brands")]
        public async Task<ActionResult<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _productsService.GetProductBrands();

            return Ok(productBrands);
        }
        [HttpGet("types")]
        public async Task<ActionResult<ProductType>> GetProductTypes()
        {
            var productTypes = await _productsService.GetProductTypes();

            return Ok(productTypes);
        }
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> CreateNewProduct([FromForm] ProductCreateDto product)
        {
            var newProduct = await _productsService.CreateProduct(product);

            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductUpdateDto>> UpdateProduct([FromForm] ProductUpdateDto product)
        {
            ProductUpdateDto updated = await _productsService.UpdateProduct(product);

            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(updated);
        }

        [HttpDelete("{productId}")]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            return Ok(await _productsService.DeleteAsync(productId));
        }

    }
}
