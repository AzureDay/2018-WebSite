using System;

namespace AzureDay.WebApp.Database.Enums
{
    [Flags]
    public enum TicketType
    {
        None = 0,
        Regular = 2,
        Workshop = 4
    }
}