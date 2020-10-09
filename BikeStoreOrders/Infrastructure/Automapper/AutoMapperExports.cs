using AutoMapper;
using BikeStoreOrders.Application.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStoreOrders.Infrastructure.Automapper
{
    public static class AutoMapperExports
    {
        public static void ConfigureProfiles(this IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<DtoProfile>();
            cfg.AddProfile<EntityProfile>();
        }
    }
}
