using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService _dicService;

        public DiscountsController(IDiscountService dicService)
        {
            _dicService = dicService;
        }
        [HttpGet]
        public async  Task<IActionResult> GetAllDiscountCoupon()
        {
            var values=await _dicService.GetAllCuponAsync();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCoupon(int id)
        {
            var value = await _dicService.GetCuponByIdAsync(id);
            return Ok(value);

        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto create)
        {
            await _dicService.CreateCuponAsync(create);
            return Ok("Kupon olusduruldu");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _dicService.DeleteCuponAsync(id);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto update)
        {
            await _dicService.UpdateCuponAsync(update);
            return Ok("deyisdrildi");
        }
    }
}
