using AzureDay.WebApp.Database.Enums;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureDay.WebApp.Database.Entities.Table
{
    public sealed class Ticket : TableEntity
    {
        [IgnoreProperty]
        public string AttendeeEmail
        {
            get => RowKey;
            set => RowKey = value;
        }

        public bool IsPayed { get; set; }

        public string CouponCode { get; set; }

        [IgnoreProperty]
        public TicketType TicketType
        {
            get
            {
                TicketType val;
                return System.Enum.TryParse(PartitionKey, true, out val) ?
                    val :
                    TicketType.None;
            }
            set => PartitionKey = value.ToString();
        }

        public int? WorkshopId { get; set; }

        public double Price { get; set; }

        public string PaymentType { get; set; }

        public Ticket()
        {
        }
    }
}
