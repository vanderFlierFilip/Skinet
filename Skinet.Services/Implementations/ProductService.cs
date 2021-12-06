using Skinet.Core.Entities;
using Skinet.Core.Interfaces;
using Skinet.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _proudctRepository;

        public ProductService(IProductRepository proudctRepository)
        {
            _proudctRepository = proudctRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var products = await _proudctRepository.GetAllProductsAsync();

            return products;
        }

        public async Task<Product> GetProduct(int productId)
        {
            var product = await _proudctRepository.GetByIdAsync(productId);

            return product;
        }
        public async Task<IEnumerable<ProductBrand>> GetProductBrands()
        {
            var productBrands = await _proudctRepository.GetProductBrandsAsync();

            return productBrands;
        }
        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            var productTypes = await _proudctRepository.GetProductTypesAsync();

            return productTypes;
        }
    }
}
