using Aleff.Pizzaria.Infra.Cross.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Api.Extensions
{
    public static class CORSExtensions
    {
        public static void UseCORS(this IApplicationBuilder app, IConfiguration configuration)
        {
            var corsSettings = configuration.LoadSettings<CORSSettings>("CORSSettings") ?? new CORSSettings().Default();

            app.UseCors(builder =>
            {
                builder
                    .WithOrigins(corsSettings.Origins)
                    .WithMethods(corsSettings.Methods)
                    .WithHeaders(corsSettings.Headers);

                builder = corsSettings.AllowCredentials
                    ? builder.AllowCredentials()
                    : builder.DisallowCredentials();
            });
        }
    }
}
