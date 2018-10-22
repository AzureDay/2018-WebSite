using AzureDay.WebApp.Config;
using AzureDay.WebApp.Database.Services.Table;
using System;
using System.Threading.Tasks;

namespace AzureDay.WebApp.Database
{
    public static class DataFactory
    {
        public static readonly Lazy<CouponService> CouponService = new Lazy<CouponService>(() => new CouponService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
        public static readonly Lazy<TicketService> TicketService = new Lazy<TicketService>(() => new TicketService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));

        public static async Task InitializeAsync()
        {
            await Task.WhenAll(
                CouponService.Value.InitializeAsync(),
                TicketService.Value.InitializeAsync()
            );
        }
    }
}
