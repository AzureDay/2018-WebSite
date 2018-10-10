using AzureDay.WebApp.Config;
using AzureDay.WebApp.Database.Enums;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureDay.WebApp.Database.Entities.Table
{
    public sealed class Coupon : TableEntity
    {
        [IgnoreProperty]
        public string Code
        {
            get => RowKey;
            set => RowKey = value;
        }

        [IgnoreProperty]
        public DiscountType DiscountType
        {
            get => (DiscountType)DiscountTypeId;
            set => DiscountTypeId = (int)value;
        }

        public int DiscountTypeId { get; set; }

        [IgnoreProperty]
        public decimal DiscountAmount
        {
            get => (decimal)DiscountAmountValue;
            set => DiscountAmountValue = (float)value;
        }

        public double DiscountAmountValue { get; set; }

        public bool IsEnabled { get; set; }

        public bool IsInfinite { get; set; }

        public int CouponsCount { get; set; }

        public Coupon()
        {
            PartitionKey = Configuration.Year;
        }
    }
}
