using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Services.ProductServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService catService)
        {
            _productService = catService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllProductAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var result = await _productService.GetByIdProductAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto create)
        {
            await _productService.CreateProductAsync(create);
            return Ok("Elave edildi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok("Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> CreateProduct(UpdateProductDto create)
        {
            await _productService.UpdateProductAsync(create);
            return Ok("yenilendi ");
        }
    }
}
