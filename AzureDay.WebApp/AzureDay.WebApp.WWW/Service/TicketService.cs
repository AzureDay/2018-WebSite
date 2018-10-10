using AzureDay.WebApp.Config;
using AzureDay.WebApp.Database;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.Database.Enums;
using AzureDay.WebApp.WWW.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureDay.WebApp.WWW.Service
{
    public sealed class TicketService
    {
        public decimal GetTicketPrice(TicketType ticketType)
        {
            switch (ticketType)
            {
                case TicketType.Regular:
                    return Configuration.TicketRegular;
                case TicketType.Workshop:
                    return Configuration.TicketWorkshop;
                case TicketType.Regular | TicketType.Workshop:
                    return Configuration.TicketRegular + Configuration.TicketWorkshop;
            }

            throw new ArgumentOutOfRangeException(nameof(ticketType));
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            var data = AppFactory.Mapper.Value.Map<Database.Entities.Table.Ticket>(ticket);

            await DataFactory.TicketService.Value.InsertOrReplaceAsync(data);
        }

        public async Task SetTicketsPayedAsync(string email, TicketType ticketType)
        {
            var data = await DataFactory.TicketService.Value.GetByKeysAsync(ticketType.ToString(), email);

            if (data == null)
            {
                return;
            }

            data.IsPayed = true;
            await DataFactory.TicketService.Value.ReplaceAsync(data);
        }

        public async Task UpdateTicketPriceAsync(string email, TicketType ticketType, decimal newPrice)
        {
            var data = await DataFactory.TicketService.Value.GetByKeysAsync(ticketType.ToString(), email);

            if (data == null)
            {
                return;
            }

            data.Price = (double)newPrice;
            await DataFactory.TicketService.Value.ReplaceAsync(data);
        }

        public async Task DeleteTicketAsync(string email, TicketType ticketType)
        {
            var data = await DataFactory.TicketService.Value.GetByKeysAsync(ticketType.ToString(), email);

            await DataFactory.TicketService.Value.DeleteAsync(data);
        }

        public async Task<List<Ticket>> GetTicketsByEmailAsync(string email)
        {
            var filter = new Dictionary<string, object> { { "RowKey", email } };

            var data = await DataFactory.TicketService.Value.GetByFilterAsync(filter);

            if (data == null)
            {
                return null;
            }

            var tickets = data
                .Select(AppFactory.Mapper.Value.Map<Ticket>)
                .ToList();

            return tickets;
        }

        public async Task<List<Ticket>> GetWorkshopTicketsAsync(int workshopId)
        {
            var filter = new Dictionary<string, object>
            {
                {nameof(Database.Entities.Table.Ticket.PartitionKey), TicketType.Workshop.ToString()},
                {nameof(Database.Entities.Table.Ticket.WorkshopId), workshopId}
            };

            var data = (await DataFactory.TicketService.Value.GetByFilterAsync(filter))
                .Select(AppFactory.Mapper.Value.Map<Ticket>)
                .ToList();

            return data;
        }

        public async Task<List<Ticket>> GetWorkshopsTicketsAsync()
        {
            var data = (await DataFactory.TicketService.Value.GetByPartitionKeyAsync(TicketType.Workshop.ToString()))
                .Select(AppFactory.Mapper.Value.Map<Ticket>)
                .ToList();

            return data;
        }
    }
}
