namespace TeamSpark.AzureDay.WebSite.Notification.Email.Model
{
	public sealed class ConfirmRegistrationMessage : MessageBase
	{
		public string Token { get; set; }
	}
}
