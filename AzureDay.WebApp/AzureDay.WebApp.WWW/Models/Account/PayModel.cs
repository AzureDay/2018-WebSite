namespace AzureDay.WebApp.WWW.Models.Account
{
    public sealed class PayModel
    {
        public bool HasConferenceTicket { get; set; }
        public bool HasWorkshopTicket { get; set; }
        public int DdlWorkshop { get; set; }
        public string PaymentType { get; set; }
        public string PromoCode { get; set; }
    }
}