using Skinet.Client.Services.Interface;
using Skinet.Model.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Skinet.Client.Services
{
    public class ProductTypesService : IProductTypesService
    {
        private readonly HttpClient _httpClient;
        public ProductTypesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductTypeDto>> GetProductTypes()
        {
            return 
                await JsonSerializer.DeserializeAsync<IEnumerable<ProductTypeDto>>
                (
                    await _httpClient.GetStreamAsync("api/types"), 
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true }
                );
        }
    }
}
