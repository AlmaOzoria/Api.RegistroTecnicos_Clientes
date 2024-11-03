using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Data.Context;

namespace Tecnicos.Data.DI;

public static class DbContextRegistar
{
    public static IServiceCollection RegisterDbContextFactory(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextFactory<TecnicosContext>(o =>
            o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), sqlOptions =>
                sqlOptions.EnableRetryOnFailure()));

        return services;
    }
}
