namespace AzureDay.WebApp.Database.Entities
{
    public sealed class Attendee
    {
        public string EMail { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}
