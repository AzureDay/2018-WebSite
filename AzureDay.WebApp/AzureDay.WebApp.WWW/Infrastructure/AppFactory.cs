using AutoMapper;
using AzureDay.WebApp.Database.Entities;
using AzureDay.WebApp.WWW.Service;
using System;

namespace AzureDay.WebApp.WWW.Infrastructure
{
    public static class AppFactory
    {
        public static readonly Lazy<IMapper> Mapper = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Attendee, Database.Entities.Table.Attendee>();
                cfg.CreateMap<Database.Entities.Table.Attendee, Attendee>();

                cfg.CreateMap<QuickAuthToken, Database.Entities.Table.QuickAuthToken>();
                cfg.CreateMap<Database.Entities.Table.QuickAuthToken, QuickAuthToken>();

                cfg.CreateMap<Coupon, Database.Entities.Table.Coupon>();
                cfg.CreateMap<Database.Entities.Table.Coupon, Coupon>();

                cfg.CreateMap<Ticket, Database.Entities.Table.Ticket>();
                cfg.CreateMap<Database.Entities.Table.Ticket, Ticket>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        });

        public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService());
        public static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() => new QuickAuthTokenService());
        public static readonly Lazy<CouponService> CouponService = new Lazy<CouponService>(() => new CouponService());
        public static readonly Lazy<TicketService> TicketService = new Lazy<TicketService>(() => new TicketService());
    }
}
