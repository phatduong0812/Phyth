﻿using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Pomelo.EntityFrameworkCore.MySql.Storage.Internal;
using Product.API.Persistence;

namespace Product.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.ConfigureProductContext(configuration);

            return services;
        }

        private static IServiceCollection ConfigureProductContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            var builder = new MySqlConnectionStringBuilder(connectionString);

            services.AddDbContext<ProductContext>(options =>
            {
                options.UseMySql(builder.ConnectionString, ServerVersion.AutoDetect(builder.ConnectionString), e =>
                {
                    e.MigrationsAssembly("Product.API");
                    e.SchemaBehavior(MySqlSchemaBehavior.Ignore);
                });
            });

            return services;
        }
    }
}
