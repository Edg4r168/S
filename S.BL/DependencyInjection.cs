using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using S.BL.Services;
using S.DAL.DataContext;
using S.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S.BL;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(
        this IServiceCollection services, 
        IConfiguration configuration
    )
    {
        services.AddScoped<IPersonService, PersonaSBL>();

        services.AddScoped<IPersonaRepository, PersonaSDAL>();

        services.AddDbContext<SDBContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("connection") ?? "", sqlServerOptions =>
            {
                sqlServerOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null
                );
            });
        });

        //services.AddScoped<SDBContext>(p => 
        //    new SDBContext(configuration.GetConnectionString("connection") ?? ""));

        return services;
    }
}
