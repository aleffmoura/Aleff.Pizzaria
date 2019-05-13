using Aleff.Pizzaria.Infra.Cross.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Api.Extensions
{
    public static class MapperExtensions
    {
        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.ConfigureProfiles(typeof(Startup), typeof(Application.AppModule));
        }
    }
}
