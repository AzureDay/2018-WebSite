namespace AzureDay.WebApp.Notification.Email.Model
{
    public sealed class RestorePasswordMessage : MessageBase
    {
        public string Token { get; set; }
    }
}
