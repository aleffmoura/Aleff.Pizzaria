using Aleff.Pizzaria.Application.Features.Orders.Handlers;
using Aleff.Pizzaria.Application.Features.Orders.ViewModels;
using Aleff.Pizzaria.Application.Features.Pizzas.Handlers;
using Aleff.Pizzaria.Domain.Features.Orders;
using Aleff.Pizzaria.Domain.Features.Pizzas;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Application.Features.Pizzas
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PizzaCreate.Command, Pizza>()
                .ForMember(x => x.Size, x => x.Ignore())
                .ForMember(x => x.Flavor, x => x.Ignore());

            CreateMap<PizzaUpdate.Command, Pizza>()
                .ForMember(pizza => pizza.Customizations,
                           opt => opt.MapFrom(pizzaCreate => string.Join(", ", pizzaCreate.Customizations)
                           ))
                .ForMember(x => x.Size, x => x.Ignore())
                .ForMember(x => x.Flavor, x => x.Ignore());
        }
    }
}
