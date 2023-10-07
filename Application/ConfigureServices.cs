using Application.Common.Interfaces;
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

            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IProvisionService, ProvisionService>();
            services.AddScoped<IDeliveryService, DeliveryService>();

            // Registra tu servicio genérico
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));


            return services;
        }
    }
}
