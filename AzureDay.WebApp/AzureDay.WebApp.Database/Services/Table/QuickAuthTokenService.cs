using AzureDay.WebApp.Database.Entities.Table;

namespace AzureDay.WebApp.Database.Services.Table
{
    public sealed class QuickAuthTokenService : TableServiceBase<QuickAuthToken>
    {
        protected override string TableName
        {
            get { return "QuickAuthToken"; }
        }

        public QuickAuthTokenService(string accountName, string accountKey)
            : base(accountName, accountKey)
        {
        }
    }
}
