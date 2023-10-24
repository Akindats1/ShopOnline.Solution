using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Services.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient) 
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ProductDto>> GetItems()
        {
            var products = await _httpClient.GetFromJsonAsync<IEnumerable<ProductDto>>("api/Products");
            return products;
         
        }
    }
}
