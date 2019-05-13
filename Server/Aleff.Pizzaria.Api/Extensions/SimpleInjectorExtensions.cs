using Aleff.Pizzaria.Domain.Features.Flavors;
using Aleff.Pizzaria.Domain.Features.Orders;
using Aleff.Pizzaria.Domain.Features.Pizzas;
using Aleff.Pizzaria.Domain.Features.Sizes;
using Aleff.Pizzaria.Infra.Cross.Extensions;
using Aleff.Pizzaria.Infra.Data.Contexts;
using Aleff.Pizzaria.Infra.Data.Features.Flavors;
using Aleff.Pizzaria.Infra.Data.Features.Orders;
using Aleff.Pizzaria.Infra.Data.Features.Pizzas;
using Aleff.Pizzaria.Infra.Data.Features.Sizes;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.AspNetCore.Mvc;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Api.Extensions
{
    public static class SimpleInjectorExtensions
    {
        public static void AddSimpleInjector(this IServiceCollection services, Container container)
        {
            // Define que a instância vai existir dentro de um determinado escopo (implícito ou explícito).
            // Assume o fluxo de controle dos métodos assíncronos automaticamente
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            services.AddSingleton<IControllerActivator>(new SimpleInjectorControllerActivator(container));
            // Ao invocar o método de extensão UseSimpleInjectorAspNetRequestScoping, o tempo que uma 
            // requisição está ativa é o período que um escopo vai estar ativo. 
            services.UseSimpleInjectorAspNetRequestScoping(container);
        }

        public static void AddDependencies(this IServiceCollection services,
            Container container,
            IConfiguration configuration)
        {
            RegisterFeatures(container);

            var appSettings = configuration.LoadSettings<AppSettings>("AppSettings", services);

            container.Register(() =>
            {
                var options = new DbContextOptionsBuilder<PizzariaDbContext>().UseSqlServer(appSettings.ConnectionString).Options;
                return new PizzariaDbContext(options);
            }, Lifestyle.Scoped);
        }

        private static void RegisterFeatures(Container container)
        {
            container.Register<IOrderRepository, OrderRepository>();
            container.Register<IPizzaRepository, PizzaRepository>();
            container.Register<ISizeRepository, SizeRepository>();
            container.Register<IFlavorRepository, FlavorRepository>();
        }
    }
}
