using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using AzureDay.WebApp.Config;
using AzureDay.WebApp.Database;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.Database.Enums;
using AzureDay.WebApp.WWW.Infrastructure;

namespace AzureDay.WebApp.WWW.Service
{
    public sealed class CouponService
    {
        public async Task<Coupon> GetValidCouponByCodeAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return null;
            }

            var normalizedCode = code.ToLower().Trim();

            var coupon = (await DataFactory.CouponService.Value.GetByFilterAsync(new Dictionary<string, object>
            {
                { "PartitionKey", Configuration.Year },
                { "RowKey", normalizedCode }
            })).FirstOrDefault();

            if (coupon == null)
            {
                return null;
            }

            if (!coupon.IsEnabled)
            {
                return null;
            }

            if (!coupon.IsInfinite && coupon.CouponsCount <= 0)
            {
                return null;
            }

            return AppFactory.Mapper.Value.Map<Coupon>(coupon);
        }

        public async Task UseCouponByCodeAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return;
            }

            var normalizedCode = code.ToLower().Trim();

            var coupon = await DataFactory.CouponService.Value.GetByKeysAsync(Configuration.Year, normalizedCode);

            if (coupon == null)
            {
                return;
            }

            if (!coupon.IsInfinite)
            {
                coupon.CouponsCount--;
                await DataFactory.CouponService.Value.ReplaceAsync(coupon);
            }
        }

        public async Task RestoreCouponByCodeAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return;
            }

            var normalizedCode = code.ToLower().Trim();

            var coupon = await DataFactory.CouponService.Value.GetByKeysAsync(Configuration.Year, normalizedCode);

            if (!coupon.IsInfinite)
            {
                coupon.CouponsCount++;
                await DataFactory.CouponService.Value.ReplaceAsync(coupon);
            }
        }

        public decimal GetPriceWithCoupon(decimal price, Coupon coupon)
        {
            if (coupon == null)
            {
                return price == Configuration.TicketRegular + Configuration.TicketWorkshop ?
                    price * 0.9m : price;
            }

            var newPrice = price;

            switch (coupon.DiscountType)
            {
                case DiscountType.Amount:
                    newPrice = price - coupon.DiscountAmount;
                    if (newPrice < 0)
                    {
                        newPrice = 0;
                    }
                    break;

                case DiscountType.Percentage:
                    newPrice = price * ((100 - coupon.DiscountAmount) / 100);
                    break;
            }

            if (price == Configuration.TicketRegular + Configuration.TicketWorkshop)
            {
                if (price * 0.9m < newPrice)
                {
                    newPrice = price * 0.9m;
                }
            }

            return newPrice;
        }
    }
}
