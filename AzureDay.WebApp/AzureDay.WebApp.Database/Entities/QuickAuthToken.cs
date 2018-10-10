namespace AzureDay.WebApp.Database.Entities
{
    public class QuickAuthToken
    {
        public string Token { get; set; }
        public string Email { get; set; }
        public bool IsUsed { get; set; }
    }
}
