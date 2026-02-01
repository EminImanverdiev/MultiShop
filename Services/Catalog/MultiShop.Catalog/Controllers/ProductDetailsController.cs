using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductDetails()
        {
            var result = await _productDetailService.GetAllProductDetailAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var result = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto create)
        {
            await _productDetailService.CreateProductDetailAsync(create);
            return Ok("Elave edildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> CreateProductDetail(UpdateProductDetailDto create)
        {
            await _productDetailService.UpdateProductDetailAsync(create);
            return Ok("yenilendi ");
        }
    }
}
