﻿using Application.Common.Interfaces;
using Application.Common.Mapper;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {

            services.AddScoped<ICoordinatesService, CoordinatesService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            

            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
