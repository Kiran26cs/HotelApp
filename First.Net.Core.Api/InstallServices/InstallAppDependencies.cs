using System;
using System.Collections.Generic;
using System.Text;
using AppManager.AppInterfaces;
using AppManager.Processors;
using Hotel.Auth.Api.Manager;
using Hotel.Auth.Api.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace First.Net.Core.Api.InstallServices
{
    public static class InstallAppDependencies
    {
        public static void InstallManagerServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenProcessor, TokenProcessor>();
            services.AddTransient<IAccountsManager, AccountsManager>();
        }

        public static void InstallRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IAccountsRepository, AccountsRepository>();
        }
    }
}
