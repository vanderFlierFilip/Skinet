using Skinet.Model.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skinet.Client.Services.Interface
{
    public interface IProductBrandsService
    {
        Task<IEnumerable<ProductBrandDto>> GetProductBrands();
    }
}
