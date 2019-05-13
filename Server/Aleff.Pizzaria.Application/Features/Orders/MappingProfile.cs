using Aleff.Pizzaria.Application.Features.Orders.Handlers;
using Aleff.Pizzaria.Application.Features.Orders.ViewModels;
using Aleff.Pizzaria.Domain.Features.Orders;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Application.Features.Orders
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderCreate.Command, Order>();
            CreateMap<OrderUpdate.Command, Order>();

            CreateMap<Order, OrderDetailViewModel>()
                .ForMember(x => x.Customizations, m => m.MapFrom(o => o.GetCustomizationsDetails()))
                .ForMember(x => x.Size, m => m.MapFrom(f => f.Pizza.Size.ESize.ToString()))
                .ForMember(x => x.Flavor, m => m.MapFrom(f => f.Pizza.Flavor.Name));
        }
    }
}
