using Skinet.Client.Services.Interface;
using Skinet.Model.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Skinet.Client.Services
{
    public class ProductsService : IProductsService
    {
        private readonly HttpClient _httpClient;

        public ProductsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
     
        public async Task<IEnumerable<ProductReadDto>> GetAllProducts()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<ProductReadDto>>
                    (await _httpClient.GetStreamAsync($"api/products"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public async Task<ProductReadDto> GetProduct(int id)
        {
            return await JsonSerializer.DeserializeAsync<ProductReadDto>
                    (await _httpClient.GetStreamAsync($"api/products/{id}"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
        public Task<ProductCreateDto> CreateProduct(ProductReadDto product)
        {
            throw new System.NotImplementedException();
        }

        public Task<ProductUpdateDto> UpdateProduct(ProductUpdateDto product)
        {
            throw new System.NotImplementedException();
        }
    }
}
