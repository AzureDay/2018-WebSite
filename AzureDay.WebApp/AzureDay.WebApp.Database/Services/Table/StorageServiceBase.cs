using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;

namespace AzureDay.WebApp.Database.Services.Table
{
    public abstract class StorageServiceBase
    {
        protected CloudStorageAccount Account { get; private set; }

        protected StorageServiceBase(string accountName, string accountKey)
        {
            var credentials = new StorageCredentials(accountName, accountKey);

            Account = new CloudStorageAccount(credentials, true);
        }
    }
}
