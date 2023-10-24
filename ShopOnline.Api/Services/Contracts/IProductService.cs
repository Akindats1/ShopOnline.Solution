using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Services.Contracts
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetItems();
    }
}
