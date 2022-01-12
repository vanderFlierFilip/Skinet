using Skinet.Model.Models;
using Skinet.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductReadDto>> GetAllProducts();
        Task<ProductReadDto> GetProduct(int productId);
        Task<IEnumerable<ProductBrandDto>> GetProductBrands();
        Task<IEnumerable<ProductTypeDto>> GetProductTypes();
        Task<ProductReadDto> CreateProduct(ProductCreateDto product);
        Task<ProductUpdateDto> UpdateProduct(ProductUpdateDto product);
        Task<bool> DeleteAsync(int id);
    }
}
