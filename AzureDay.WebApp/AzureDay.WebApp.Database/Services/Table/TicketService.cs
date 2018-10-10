using AzureDay.WebApp.Database.Entities.Table;

namespace AzureDay.WebApp.Database.Services.Table
{
    public class TicketService : TableServiceBase<Ticket>
    {
        protected override string TableName
        {
            get { return "Ticket"; }
        }

        public TicketService(string accountName, string accountKey)
            : base(accountName, accountKey)
        {
        }
    }
}
