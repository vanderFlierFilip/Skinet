using Skinet.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skinet.Client.Services.Interface
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductReadDto>> GetAllProducts();
        Task<ProductReadDto> GetProduct(int id);
        Task<ProductCreateDto> CreateProduct(ProductReadDto product);
        Task<ProductUpdateDto> UpdateProduct(ProductUpdateDto product);
    }
}
