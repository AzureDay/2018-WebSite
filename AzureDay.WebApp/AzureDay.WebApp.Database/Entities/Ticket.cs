using AzureDay.WebApp.Database.Enums;

namespace AzureDay.WebApp.Database.Entities
{
    public sealed class Ticket
    {
        public Attendee Attendee { get; set; }

        public bool IsPayed { get; set; }

        public Coupon Coupon { get; set; }

        public TicketType TicketType { get; set; }

        public double Price { get; set; }

        public string PaymentType { get; set; }
        public int? WorkshopId { get; set; }
    }
}
