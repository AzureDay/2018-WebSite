using AzureDay.WebApp.Config;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureDay.WebApp.Database.Entities.Table
{
    public class QuickAuthToken : TableEntity
    {
        [IgnoreProperty]
        public string Token
        {
            get { return RowKey; }
            set { RowKey = value; }
        }

        public string Email { get; set; }
        public bool IsUsed { get; set; }

        public QuickAuthToken()
        {
            PartitionKey = Configuration.Year;
        }
    }
}
