using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<GetProductDto> GetByIdProductAsync(string id);
        Task CreateProductAsync(CreateProductDto create);
        Task UpdateProductAsync(UpdateProductDto update);
        Task DeleteProductAsync(string id);
    }
}
