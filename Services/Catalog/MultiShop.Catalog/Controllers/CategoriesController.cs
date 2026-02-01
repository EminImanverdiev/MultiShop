using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.CategoryDtos;
using MultiShop.Catalog.Services.CategoryServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
      private readonly  ICategoryService _catService;

        public CategoriesController(ICategoryService catService)
        {
            _catService = catService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var result=await _catService.GetAllCategoryAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            var result = await _catService.GetByIdCategoryAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto create)
        {
            await _catService.CreateCategoryAsync(create);
            return Ok("Elave edildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _catService.DeleteCategoryAsync(id);
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> CreateCategory(UpdateCategoryDto create)
        {
            await _catService.UpdateCategoryAsync(create);
            return Ok("yenilendi ");
        }
    }
}
