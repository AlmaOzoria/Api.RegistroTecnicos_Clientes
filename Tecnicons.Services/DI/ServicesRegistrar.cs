using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Data.DI;
using Tecnicos.Abstractions;

namespace Tecnicos.Services.DI;

public static class ServicesRegistrar
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterDbContextFactory(configuration);
        services.AddScoped<IClienteService, ClienteService>();
        return services;
    }
}