using Skinet.Client.Services.Interface;
using Skinet.Model.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Skinet.Client.Services
{
    public class ProductBrandsService : IProductBrandsService
    {
        private readonly HttpClient _httpClient;

        public ProductBrandsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductBrandDto>> GetProductBrands()
        {
            return 
                await JsonSerializer.DeserializeAsync<IEnumerable<ProductBrandDto>>
                (
                    await _httpClient.GetStreamAsync("api/brands"),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
        }
    }
}
