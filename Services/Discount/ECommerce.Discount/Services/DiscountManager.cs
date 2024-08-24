using Dapper;
using ECommerce.Discount.Context;
using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
    public class DiscountManager : IDiscountService
    {
        private readonly DiscountDapperContext _discountDapperContext;

        public DiscountManager(DiscountDapperContext discountDapperContext)
        {
            _discountDapperContext = discountDapperContext;
        }

        public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
        {
            var query = "insert into coupons(Code,Rate,IsActive,ValidDate) values(@code,@rate,@isActive,@validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDto.Code);
            parameters.Add("@rate", createCouponDto.Rate);
            parameters.Add("@isActive", createCouponDto.IsActive);
            parameters.Add("@validDate", createCouponDto.ValidDate);

            using (var connection = _discountDapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task DeleteCouponAsync(int id)
        {
            var query = "Delete From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _discountDapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultCouponDto>> GetAllCouponAsync()
        {
            var query = "Select * From Coupons";
            using (var connection = _discountDapperContext.CreateConnection())
            {
                var coupons = await connection.QueryAsync<ResultCouponDto>(query);
                return coupons.ToList();

            }
        }

        public async Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
        {
            string query = "Select * From Coupons where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using (var connection = _discountDapperContext.CreateConnection())
            {
                var coupon = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query,parameters);
                return coupon;
            }
        }

        public async Task<ResultCouponDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "Select * From Coupons where Code=@code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _discountDapperContext.CreateConnection())
            {
                var coupon = await connection.QueryFirstOrDefaultAsync<ResultCouponDto>(query, parameters);
                return coupon;
            }
        }

        public async Task<int> GetDiscountCouponCount()
        {
            string query = "Select Count(*) From Coupons";
            using (var connection = _discountDapperContext.CreateConnection())
            {
                var count = await connection.QueryFirstOrDefaultAsync<int>(query);
                return count;

            }
        }

        public async Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDto.Code);
            parameters.Add("@rate", updateCouponDto.Rate);
            parameters.Add("@isActive", updateCouponDto.IsActive);
            parameters.Add("@validDate", updateCouponDto.ValidDate);
            parameters.Add("@couponId", updateCouponDto.CouponId);

            using (var connection = _discountDapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
