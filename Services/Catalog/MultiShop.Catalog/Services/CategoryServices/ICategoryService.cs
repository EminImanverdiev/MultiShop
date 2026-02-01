using MultiShop.Catalog.Dtos.CategoryDtos;

namespace MultiShop.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<GetCategoryDto> GetByIdCategoryAsync(string id);
        Task CreateCategoryAsync(CreateCategoryDto create);
        Task UpdateCategoryAsync(UpdateCategoryDto update);
        Task DeleteCategoryAsync(string id);

    }
}
