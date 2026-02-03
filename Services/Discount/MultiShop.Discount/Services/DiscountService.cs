using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using MultiShop.Discount.Context;
using MultiShop.Discount.Dtos;

namespace MultiShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateCuponAsync(CreateDiscountCouponDto create)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code",create.Code);
            parameters.Add("@rate",create.Rate);
            parameters.Add("@isActive",create.isActive);
            parameters.Add("@validDate", create.ValidDate);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task DeleteCuponAsync(int id)
        {
            string query = "Delete from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId",id);
            using (var connection=_context.CreateConnection())
            {
                await connection.ExecuteAsync(query,parameters);
            }
        }

        public async Task<List<ResultDiscountCouponDto>> GetAllCuponAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
                return values.ToList();
            }

        }

        public async Task<GetDiscountCouponDto> GetCuponByIdAsync(int id)
        {
            string query = "Select * from Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId",id);
            using (var connection = _context.CreateConnection())
            {
                var value = await connection.QueryFirstOrDefaultAsync<GetDiscountCouponDto>(query);
                return value;
            }
        }

        public async Task UpdateCuponAsync(UpdateDiscountCouponDto update)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", update.Code);
            parameters.Add("@rate", update.Rate);
            parameters.Add("@isActive", update.isActive);
            parameters.Add("@validDate", update.ValidDate);
            parameters.Add("@couponId", update.CouponId);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }

        }
    }
}
