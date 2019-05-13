using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Cross.Extensions
{
    public static class SettingsExtensions
    {
        public static T LoadSettings<T>(this IConfiguration configuration, string sectionName, IServiceCollection service = null) where T : class
        {
            var sections = configuration.GetSection(sectionName);
            service?.Configure<T>(sections);

            var settings = sections.Get<T>();
            return settings;
        }
    }
}
