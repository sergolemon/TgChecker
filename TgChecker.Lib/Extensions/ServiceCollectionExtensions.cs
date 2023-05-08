using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TgChecker.Lib.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTgCheckerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EfSQLiteDbContext>(cfg => cfg.UseSqlite(configuration.GetConnectionString("SQLiteConnStr")));

            services.AddSingleton<TgCheckerService>();

            return services;
        }
    }
}
