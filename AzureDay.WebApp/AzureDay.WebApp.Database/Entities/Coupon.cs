using AzureDay.WebApp.Database.Enums;

namespace AzureDay.WebApp.Database.Entities
{
    public sealed class Coupon
    {
        public string Code { get; set; }

        public DiscountType DiscountType { get; set; }

        public decimal DiscountAmount
        { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsInfinite { get; set; }

        public int? CouponsCount { get; set; }
    }
}
