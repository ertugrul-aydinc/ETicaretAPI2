using ETicaretAPI2.Application.Abstractions.Hubs;
using ETicaretAPI2.SignalR.HubServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI2.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection services)
        {
            services.AddTransient<IProductHubService,ProductHubService>();
            services.AddTransient<IOrderHubService,OrderHubService>();
            services.AddSignalR();
        }
    }
}
