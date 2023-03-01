
using ETicaretAPI2.Application.Abstractions.Services;
using ETicaretAPI2.Application.Abstractions.Services.Configurations;
using ETicaretAPI2.Application.Abstractions.Storage;
using ETicaretAPI2.Application.Abstractions.Token;
using ETicaretAPI2.Infrastructure.Services;
using ETicaretAPI2.Infrastructure.Services.Configurations;
using ETicaretAPI2.Infrastructure.Services.Storage;
using ETicaretAPI2.Infrastructure.Services.Token;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI2.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IStorageService, StorageService>();
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddScoped<IMailService, MailService>();
            services.AddScoped<IApplicationService, ApplicationService>();
        }

        public static void AddStorage<T>(this IServiceCollection services) where T : Storage, IStorage
        {
            services.AddScoped<IStorage, T>();
        }
    }
}
