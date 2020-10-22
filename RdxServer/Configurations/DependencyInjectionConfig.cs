using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;
using RdxServer.Business;
using RdxServer.Business.Interfaces;
using RdxServer.Context;
using RdxServer.DTO;
using RdxServer.Entities;
using RdxServer.Repositories;
using RdxServer.Repositories.Interfaces;
using RdxServer.Validators;
using RdxServer.Validators.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<RdxDBContext>();
            services.AddScoped<IEventBusiness, EventBusiness>();
            services.AddScoped<IDeviceEventRepository, DeviceEventRepository>();
            services.AddScoped<IValidatable<DeviceEventDTO>, DeviceEventDTOValidator>();

            return services;
        }
    }
}
