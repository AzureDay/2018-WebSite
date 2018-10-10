using AzureDay.WebApp.Config;
using AzureDay.WebApp.Database.Services.Table;
using System;
using System.Threading.Tasks;

namespace AzureDay.WebApp.Database
{
    public static class DataFactory
    {
        public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
        public static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() => new QuickAuthTokenService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
        public static readonly Lazy<CouponService> CouponService = new Lazy<CouponService>(() => new CouponService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
        public static readonly Lazy<TicketService> TicketService = new Lazy<TicketService>(() => new TicketService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));

        public static async Task InitializeAsync()
        {
            await Task.WhenAll(
                AttendeeService.Value.InitializeAsync(),
                QuickAuthTokenService.Value.InitializeAsync(),
                CouponService.Value.InitializeAsync(),
                TicketService.Value.InitializeAsync()
            );
        }
    }
}
