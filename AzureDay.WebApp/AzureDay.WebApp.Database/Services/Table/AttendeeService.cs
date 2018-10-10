using AzureDay.WebApp.Database.Entities.Table;

namespace AzureDay.WebApp.Database.Services.Table
{
    public class AttendeeService : TableServiceBase<Attendee>
    {
        protected override string TableName
        {
            get { return "Attendee"; }
        }

        public AttendeeService(string accountName, string accountKey)
            : base(accountName, accountKey)
        {
        }
    }
}
