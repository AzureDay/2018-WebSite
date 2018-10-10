using AzureDay.WebApp.Config;

namespace AzureDay.WebApp.Notification.Email.Ext
{
    public partial class RestorePassword
    {
        public string Year => Configuration.Year;
        public string Host => Configuration.Host;
        public string ConfirmationCode { get; set; }
    }
}