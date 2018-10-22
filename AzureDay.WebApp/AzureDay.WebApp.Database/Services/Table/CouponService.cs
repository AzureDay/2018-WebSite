using AzureDay.WebApp.Database.Entities.Table;

namespace AzureDay.WebApp.Database.Services.Table
{
    public class CouponService : TableServiceBase<CouponTableEntity>
    {
        protected override string TableName
        {
            get { return "Coupon"; }
        }

        public CouponService(string accountName, string accountKey)
            : base(accountName, accountKey)
        {
        }
    }
}
