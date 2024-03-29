﻿using Microsoft.EntityFrameworkCore;
using VariacaoAtivoApi.Data;

namespace VariacaoAtivoApi.Configuration
{
    public static class EntityFrameworkConfig
    {
        public static IServiceCollection ConfigureEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    connectionString,
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    })
            );

            return services;
        }
    }
}
