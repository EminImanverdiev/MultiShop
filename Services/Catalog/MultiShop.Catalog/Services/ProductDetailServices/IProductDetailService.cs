using MultiShop.Catalog.Dtos.ProductDetailDtos;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<GetProductDetailDto> GetByIdProductDetailAsync(string id);
        Task CreateProductDetailAsync(CreateProductDetailDto create);
        Task UpdateProductDetailAsync(UpdateProductDetailDto update);
        Task DeleteProductDetailAsync(string id);
    }
}
