﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Services;

namespace TaskControl.Backend.TaskControl.Ioc
{
    public static class AppServiceCollectionExtension
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            services.AddTransient<LoginAppService>();
            services.AddTransient<UserAppService>();
        }

        private static void RegisterGeneralServices(this IServiceCollection services)
        {
            RegisterAppServices(services);
        }

        public static void RegisterForDevelopment(this IServiceCollection services)
        {
            RegisterGeneralServices(services);
        }
    }
}
