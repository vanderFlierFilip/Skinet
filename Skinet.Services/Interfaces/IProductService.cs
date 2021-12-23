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
        Task<IEnumerable<ProductBrand>> GetProductBrands();
        Task<IEnumerable<ProductType>> GetProductTypes();

    }
}
