using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Application.Mapping
{
    public class MapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(MapperInitializer));
            });
        }
        public static void Reset() => Mapper.Reset();
    }
}
