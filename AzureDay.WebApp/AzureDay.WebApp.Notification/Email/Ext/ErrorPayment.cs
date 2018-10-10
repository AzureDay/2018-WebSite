using AzureDay.WebApp.Config;

namespace AzureDay.WebApp.Notification.Email.Ext
{
    public partial class ErrorPayment
    {
        public string Year => Configuration.Year;
        public string Host => Configuration.Host;
    }
}
