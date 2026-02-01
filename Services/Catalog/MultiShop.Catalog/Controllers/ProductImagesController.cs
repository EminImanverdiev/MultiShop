using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _ProductImageService;

        public ProductImagesController(IProductImageService ProductImageService)
        {
            _ProductImageService = ProductImageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductImages()
        {
            var result = await _ProductImageService.GetAllProductImageAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var result = await _ProductImageService.GetByIdProductImageAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto create)
        {
            await _ProductImageService.CreateProductImageAsync(create);
            return Ok("Elave edildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await _ProductImageService.DeleteProductImageAsync(id);
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> CreateProductImage(UpdateProductImageDto create)
        {
            await _ProductImageService.UpdateProductImageAsync(create);
            return Ok("yenilendi ");
        }
    }
}
