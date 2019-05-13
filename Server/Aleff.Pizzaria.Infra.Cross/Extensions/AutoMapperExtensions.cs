using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Cross.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void ConfigureProfiles(this object any, params Type[] types)
        {
            Mapper.Reset();
            Mapper.Initialize(cfg =>
            {
                foreach (Type type in types)
                {
                    cfg.AddProfiles(type);
                }
            });
        }
    }
}
