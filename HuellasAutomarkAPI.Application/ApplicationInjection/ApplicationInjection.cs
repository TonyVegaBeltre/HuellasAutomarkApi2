using HuellasAutomarkAPI.Application.Interfaces;
using HuellasAutomarkAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuellasAutomarkAPI.Application.ApplicationInjection
{
    public static class ApplicationInjection
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {

            // Servicios específicos
            //services.AddScoped<IClient/*, ClientService*/>();
            //services.AddScoped<ICampaign/*, CampaignService*/>();
            services.AddScoped<IClientCampaign, ClientCampaignService>();
            services.AddScoped<IClientCampaign, ClientCampaignService>();
            services.AddScoped<DashboardService>();
            // Otros servicios de infraestructura, repositorios, etc.
            // services.AddScoped<IOtherService, OtherService>();

            return services;
        }
    }
}
