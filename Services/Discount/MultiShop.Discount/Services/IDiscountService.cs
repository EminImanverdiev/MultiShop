using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllCuponAsync();
        Task CreateCuponAsync(CreateDiscountCouponDto create);
        Task UpdateCuponAsync(UpdateDiscountCouponDto update);
        Task DeleteCuponAsync(int id);
        Task<GetDiscountCouponDto> GetCuponByIdAsync(int id);


    }
}
