using AzureDay.WebApp.Config;

namespace TeamSpark.AzureDay.WebSite.Notification.Email.Template
{
	public partial class ConfirmPayment
	{
		public string Year => Configuration.Year;
		public string Host => Configuration.Host;
	}
}
