using MultiShop.Catalog.Dtos.ProductImageDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
        Task<GetProductImageDto> GetByIdProductImageAsync(string id);
        Task CreateProductImageAsync(CreateProductImageDto create);
        Task UpdateProductImageAsync(UpdateProductImageDto update);
        Task DeleteProductImageAsync(string id);
    }
}
