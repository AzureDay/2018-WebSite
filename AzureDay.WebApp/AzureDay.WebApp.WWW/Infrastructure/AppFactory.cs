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
                cfg.CreateMap<Coupon, Database.Entities.Table.CouponTableEntity>();
                cfg.CreateMap<Database.Entities.Table.CouponTableEntity, Coupon>();

                cfg.CreateMap<Ticket, Database.Entities.Table.TicketTableEntity>();
                cfg.CreateMap<Database.Entities.Table.TicketTableEntity, Ticket>();
            });

            var mapper = config.CreateMapper();

            return mapper;
        });

        public static readonly Lazy<CouponService> CouponService = new Lazy<CouponService>(() => new CouponService());
        public static readonly Lazy<TicketService> TicketService = new Lazy<TicketService>(() => new TicketService());
    }
}
