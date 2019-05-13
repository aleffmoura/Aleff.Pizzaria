using Aleff.Pizzaria.Api.Filters;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aleff.Pizzaria.Api.Extensions
{
    public static class MvcExtensions
    {
        public static void AddFilters(this IServiceCollection services)
        {
            services.AddMvc(options => options.Filters.Add(new ExceptionHandlerAttribute()));
        }
    }
}
